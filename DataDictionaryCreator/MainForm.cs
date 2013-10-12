using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Collections;
using DataDictionaryCreator.Properties;
using System.Deployment.Application;

namespace DataDictionaryCreator
{
    public partial class Main : Form
    {
        #region - Internal properties -

        private string sqlConnectionString
        {
            get { return Properties.Settings.Default.SQL_CONNECTION_STRING; }
            set
            {
                Properties.Settings.Default.SQL_CONNECTION_STRING = value;
                Properties.Settings.Default.Save();

                //TODO: Review this code.  Why can't the connectionstring == value? Does it make a difference to setup again?
                if (connection != null) //&& connection.ConnectionString != value)
                {
                    DocumentationSetup(value);
                    btnConnect.Visible = false;
                }
            }
        }

        private string additionalProperties
        {
            get { return Properties.Settings.Default.ADDITIONAL_PROPERTIES; }
            set
            {
                Properties.Settings.Default.ADDITIONAL_PROPERTIES = value.TrimEnd(',');
                Properties.Settings.Default.Save();
                FillSelectedTableToDocument();
            }
        }

        private string foreignKeyDescription
        {
            get { return Properties.Settings.Default.FOREIGN_KEY_DESCRIPTION; }
            set
            {
                Properties.Settings.Default.FOREIGN_KEY_DESCRIPTION = value;
                Properties.Settings.Default.Save();
            }
        }

        private string primaryKeyDescription
        {
            get { return Properties.Settings.Default.PRIMARY_KEY_DESCRIPTION; }
            set
            {
                Properties.Settings.Default.PRIMARY_KEY_DESCRIPTION = value;
                Properties.Settings.Default.Save();
            }
        }

        private string[] additionalPropertiesArray
        {
            get
            {
                if (additionalProperties.Length == 0)
                {
                    return new string[0];
                }
                else
                {
                    string[] items = additionalProperties.Split(',');

                    List<string> reservedProperties = new List<string>();
                    reservedProperties.Add("Column");
                    reservedProperties.Add("Datatype");
                    reservedProperties.Add("Description");
                    reservedProperties.Add("Number");
                    reservedProperties.Add("Size");
                    reservedProperties.Add("Nullable");
                    reservedProperties.Add("InPrimaryKey");
                    reservedProperties.Add("IsForeignKey");

                    List<string> noDups = new List<string>();

                    for (int i = 0; i < items.Length; i++)
                    {
                        //Not Empty AND Not already in the list AND Not reserved
                        if (items[i].Trim().Length > 0
                            && !noDups.Exists(obj => string.Compare(obj, items[i].Trim(), true) == 0)
                            && !reservedProperties.Exists(obj => string.Compare(obj, items[i].Trim(), true) == 0)
                            )
                        {
                            noDups.Add(items[i].Trim());
                        }
                    }

                    return noDups.ToArray();
                }
            }
        }

        private bool allowOverwrite
        {
            get { return Properties.Settings.Default.ALLOW_OVERWRITE; }
            set
            {
                Properties.Settings.Default.ALLOW_OVERWRITE = value;
                Properties.Settings.Default.Save();
            }
        }

        private string connectionStatusDetails = string.Empty;
        private string connectionExceptionDetails = string.Empty;

        SqlConnection connection;
        Server server;
        Database db;
        Table table;

        private enum tabpages
        {
            tabPageConnect, tabPageAdvancedSettings, tabPageDocumentDatabase, tabPageImportDocumentation,
            tabPageExportDocumentation
                , tabPageTables, tabPageViews
        }

        #endregion

        #region - Public -

        public Main()
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("fr-fr");

            Application.EnableVisualStyles();
            Application.DoEvents();
            InitializeComponent();
        }

        #endregion

        #region - Private -

        /// <summary>
        /// Application Launch Point
        /// </summary>        
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Hide the "Update Available!" menu item until we can verify
            updateAvailableToolStripMenuItem.Visible = false;

            bgwUpdater.RunWorkerAsync();

            //Remove view tp for release.
            tabContainerObjects.TabPages.Remove(tabPageViews);

            ApplicationSetup();
            DocumentationSetup(sqlConnectionString);
        }

        /// <summary>
        /// Set form field values based on established user settings
        /// </summary>
        private void ApplicationSetup()
        {
            txtPrimaryKeyDescription.Text = primaryKeyDescription;
            txtForeignKeyDescription.Text = foreignKeyDescription;
            chkOverwriteDescriptions.Checked = allowOverwrite;
            txtAdditionalProperties.Text = additionalProperties;
            Properties.Settings.Default.ExcludedObjects = Properties.Settings.Default.ExcludedObjects ?? new ExcludedObjectList();
        }

        /// <summary>
        /// Using the current database connection, load the tables to be documented.
        /// </summary>
        /// <param name="sqlConnectionString">SQL Connection String</param>
        private void DocumentationSetup(string sqlConnectionString)
        {
            BeginAction(Resources.DocumentationSetupBeginAction, 100);

            try
            {
                connection = new SqlConnection(sqlConnectionString);
                server = new Server(new ServerConnection(connection));
                //server.SetDefaultInitFields(typeof(Table), "IsSystemObject");

                db = server.Databases[connection.Database];
                //Preload all table information, this is stop SMO from making unnecessary round trips. Increasing performance X 9000
                db.PrefetchObjects(typeof(Table));

                // Check role.  Without DBO (or greater) priveledges, SMO can not be used.
                if (!db.IsDbOwner)
                {
                    SetConnectionState(false, Resources.ConnectionErrorDBORequired, Resources.ConnectionErrorDBORequired, Color.Orange);
                }
                else
                {
                    // Get fields (in addition to description) the user wishes to document.
                    // These will be displayed in the grid
                    if (string.IsNullOrEmpty(additionalProperties))
                        QueryForAdditionalProperties();
                    else
                        txtAdditionalProperties.Text = additionalProperties;

                    //Default
                    SetupTableDocumentation();

                    // Brag out your success
                    SetConnectionState(true, string.Format(Resources.ConnectionSuccessGeneric, server.Name, db.Name), string.Empty, Color.Green);
                }
            }
            catch (Exception ex)
            {
                SetConnectionState(false, Resources.ConnectionErrorGeneric, ex.GetBaseException().Message, Color.Red);
            }
            finally
            {
                EndAction(Resources.DocumentSetupEndAction);
            }
        }

        /// <summary>
        /// Toggle control visibility and set text based on connection state
        /// </summary>
        /// <param name="isConnected">true if connected, otherwise false</param>
        /// <param name="statusMessage">message to be displayed on connection tab and status bar</param>
        /// <param name="exceptionMessage">used to identify error condition and used for detail error message</param>
        /// <param name="statusColor">green for success, red for failure</param>
        private void SetConnectionState(bool isConnected, string statusMessage, string exceptionMessage, Color statusColor)
        {
            // Success or failed status to user
            if (isConnected)
            {
                connectionStatusDetails = statusMessage;  // You are connected.  Congratulations!
                this.Text = String.Format(Resources.ApplicationTitle, " - " + server.ToString() + "." + db.ToString());
            }
            else if (!string.IsNullOrEmpty(exceptionMessage))
            {
                connectionStatusDetails = Resources.ConnectionErrorGenericDetailed;  // Not connected due to error                
            }
            else
            {
                connectionStatusDetails = Resources.ConnectionNotConnected;  // You didn't even try.                
            }

            // Connect tab settings
            lblConnectionSuccess.Text = connectionStatusDetails;
            lblConnectionSuccess.ForeColor = statusColor;
            btnAdvancedSettings.Visible = isConnected;
            btnDocumentDatabase.Visible = isConnected;

            // Document tab values
            lnkException.Visible = !isConnected;

            // Status bar text
            toolStripStatusLabel.Text = statusMessage;

            // Not-so-friend error message to be displayed only when asked for...
            connectionExceptionDetails = exceptionMessage;

            // Enable/Disable tabs based on connection status
            foreach (TabPage tp in tabContainerMain.TabPages)
            {
                if (tp.Name != tabpages.tabPageConnect.ToString())
                {
                    tp.Enabled = isConnected;
                }
            }

            foreach (TabPage tp in tabContainerObjects.TabPages)
            {
                tp.Enabled = isConnected;
            }
        }

        /// <summary>
        /// If Additonal Properties aren't stored in user settings, try to determine which properties were previously used. 
        /// TODO: Ask Jon what the heck this is all about.
        /// </summary>
        private void QueryForAdditionalProperties()
        {
            SqlDataReader dr;
            string previousAdditionalProperties = string.Empty;

            try
            {
                string sqlCommand = GetSql("sql.read_previous_properties.sql");
                dr = server.ConnectionContext.ExecuteReader(sqlCommand);

                while (dr.Read())
                {
                    previousAdditionalProperties += dr["name"].ToString() + ",";
                }

                // We're going to explicitly close the reader here.      
                dr.Close();

                if (!string.IsNullOrEmpty(previousAdditionalProperties))
                {
                    previousAdditionalProperties.TrimEnd(',');

                    // We've identified additional properties so set the private variable, the settings as well as the form field.
                    additionalProperties = previousAdditionalProperties;
                    txtAdditionalProperties.Text = previousAdditionalProperties;
                }

                #region "Code Jon Is Afraid To Throw Away"

                ////This was the previous code using SMO. My hunch is that it's slower.
                ////If possible, the SMO code should be used since it doesn't require database version logic.
                //ArrayList extProperties = new ArrayList();
                //foreach (ExtendedProperty ep in db.Tables[0].Columns[0].ExtendedProperties)
                //{
                //    if (ep.Name != SmoUtil.DESCRIPTION_PROPERTY)
                //        extProperties.Add(ep.Name);
                //}

                //string determinedProperties = string.Join(",", (String[])extProperties.ToArray(typeof(string)));
                //if (!string.IsNullOrEmpty(determinedProperties))
                //    this.additionalProperties = determinedProperties;

                #endregion
            }
            catch (SqlException sqlEx)
            {
                this.connectionStatusDetails = sqlEx.Message;
            }
            finally
            {
                dr = null;
            }
        }

        /// <summary>
        /// Populate the select table fields to be documented
        /// </summary>
        private void FillSelectedTableToDocument()
        {
            BeginAction(Resources.DocumentLoadTableBeginAction, 100);

            if (ddlTables.SelectedIndex >= 0)
            {
                // Select by index rather than name since names aren't consistently populated in SQL2K with a user account
                table = SmoUtil.GetTableByName(db, ddlTables.SelectedItem.ToString());
                if (table.ExtendedProperties.Contains(SmoUtil.DESCRIPTION_PROPERTY))
                    txtTableDescription.Text = table.ExtendedProperties[SmoUtil.DESCRIPTION_PROPERTY].Value.ToString();
                else
                    txtTableDescription.Text = string.Empty;

                chkExcludedTable.Checked = Properties.Settings.Default.ExcludedObjects.Exists(obj => obj == new ExcludedObject(table));

                DataTable columnList = new DataTable();
                columnList.Columns.Add("Number");
                columnList.Columns.Add("Column");
                columnList.Columns.Add("Datatype");
                columnList.Columns.Add("Size");
                columnList.Columns.Add("Nullable");
                columnList.Columns.Add("InPrimaryKey");
                columnList.Columns.Add("IsForeignKey");
                columnList.Columns.Add("Description");

                foreach (string property in additionalPropertiesArray)
                    columnList.Columns.Add(property);

                foreach (Column column in table.Columns)
                {
                    DataRow row = columnList.NewRow();
                    row["Number"] = column.ID;
                    row["Column"] = column.Name;
                    row["Datatype"] = SmoUtil.GetDatatypeString(column);
                    row["Size"] = column.DataType.MaximumLength;
                    row["Nullable"] = column.Nullable == true ? "Y" : "N";
                    row["InPrimaryKey"] = column.InPrimaryKey == true ? "Y" : "N";
                    row["IsForeignKey"] = column.IsForeignKey == true ? "Y" : "N";

                    AddColumnToGrid(column, row, "Description", SmoUtil.DESCRIPTION_PROPERTY);

                    foreach (string property in additionalPropertiesArray)
                        AddColumnToGrid(column, row, property, property);

                    columnList.Rows.Add(row);
                }

                dgvColumns.DataSource = columnList;
                FormatReadonlyColumn(dgvColumns.Columns["Number"]);
                FormatReadonlyColumn(dgvColumns.Columns["Column"]);
                FormatReadonlyColumn(dgvColumns.Columns["Datatype"]);
                FormatReadonlyColumn(dgvColumns.Columns["Size"]);
                FormatReadonlyColumn(dgvColumns.Columns["Nullable"]);
                FormatReadonlyColumn(dgvColumns.Columns["InPrimaryKey"]);
                FormatReadonlyColumn(dgvColumns.Columns["IsForeignKey"]);
            }

            // This is Ben's silly way of trying to make the document grid look pretty:
            // Set the height of the grid to the same height as the included rows or set to a max height
            int RequiredGridHeight = dgvColumns.Rows.GetRowsHeight(DataGridViewElementStates.None) + dgvColumns.ColumnHeadersHeight;

            if (RequiredGridHeight > Convert.ToInt32(Resources.DocumentMaxGridHeight))
                dgvColumns.Height = Convert.ToInt32(Resources.DocumentMaxGridHeight);
            else
                dgvColumns.Height = RequiredGridHeight;

            EndAction(Resources.DocumentLoadTableEndAction);
        }

        /// <summary>
        /// Format readonly fields
        /// </summary>
        /// <param name="column">column</param>
        private void FormatReadonlyColumn(DataGridViewColumn column)
        {
            column.ReadOnly = true;
            column.DefaultCellStyle.BackColor = Color.AliceBlue;
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        /// <summary>
        /// Add extended properties columns to grid
        /// </summary>
        /// <param name="column">column</param>
        /// <param name="row">row</param>
        /// <param name="gridName">grid name</param>
        /// <param name="propertyName">extended property name</param>
        private void AddColumnToGrid(Column column, DataRow row, string gridName, string propertyName)
        {
            ExtendedPropertyCollection extendedProperties = column.ExtendedProperties;
            if (extendedProperties.Contains(propertyName))
                row[gridName] = column.ExtendedProperties[propertyName].Value;
            else
                row[gridName] = null;
        }

        /// <summary>
        /// Begin action manages progress bar and mousepointers
        /// </summary>
        /// <param name="message">status message</param>
        /// <param name="progressMax">int representing max progress value</param>
        private void BeginAction(string message, int progressMax)
        {
            Cursor.Current = Cursors.WaitCursor;
            btnExport.Enabled = false;
            btnSetKeyDescriptions.Enabled = false;
            toolStripProgressBar.Maximum = progressMax;
            toolStripProgressBar.Visible = true;
            toolStripStatusLabel.Text = message;
            statusStrip.Refresh();
        }

        /// <summary>
        /// End action manages progress bar and mousepointers
        /// </summary>
        /// <param name="message">final status message</param>
        private void EndAction(string message)
        {
            toolStripProgressBar.Visible = false;
            toolStripProgressBar.Value = 0;
            toolStripStatusLabel.Text = message;
            Cursor.Current = Cursors.Default;
            btnExport.Enabled = true;
            btnSetKeyDescriptions.Enabled = true;
        }

        /// <summary>
        /// Establish the extended property and associated value
        /// </summary>
        /// <param name="table">table to be updated</param>
        /// <param name="databasePropertyName">extended property</param>
        /// <param name="value">value</param>
        /// <param name="columnName">column</param>
        /// <param name="overwrite">overwrite</param>
        private void SetPropertyValue(Table table, string databasePropertyName, string value, string columnName, bool overwrite)
        {
            Column column = table.Columns[columnName];
            if (column == null)
            {
                throw new Exception(string.Format(Resources.MissingColumnException, table.ToString(), columnName));
            }

            SetPropertyValue(table, databasePropertyName, value, column, overwrite);
        }

        /// <summary>
        /// Establish the extended property and associated value
        /// </summary>
        /// <param name="table">table to be updated</param>
        /// <param name="databasePropertyName">extended property</param>
        /// <param name="value">value</param>
        /// <param name="column">column</param>
        /// <param name="overwrite">overwrite</param>
        private void SetPropertyValue(Table table, string databasePropertyName, string value, Column column, bool overwrite)
        {
            if (!column.ExtendedProperties.Contains(databasePropertyName))
            {
                column.ExtendedProperties.Add(new ExtendedProperty(column, databasePropertyName, value));
            }
            else
            {
                if (overwrite || string.IsNullOrEmpty(column.ExtendedProperties[databasePropertyName].Value.ToString()))
                {
                    column.ExtendedProperties[databasePropertyName].Value = value;
                    column.ExtendedProperties[databasePropertyName].Alter();
                }
            }
            column.Alter();
        }

        /// <summary>
        /// Increment the progress bar
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        private void ProgressUpdate(object Sender, EventArgs e)
        {
            toolStripProgressBar.Value++;
        }

        /// <summary>
        /// Establish a description for the currently documented table
        /// </summary>
        /// <param name="description"></param>
        private void SetTableDescription(string description)
        {
            SetTableDescription(table, description);
        }

        /// Establish a description for table provided
        private void SetTableDescription(Table updateTable, string description)
        {
            BeginAction(Resources.TableDescriptionBeginAction, 100);

            if (!updateTable.ExtendedProperties.Contains(SmoUtil.DESCRIPTION_PROPERTY))
            {
                updateTable.ExtendedProperties.Add(new ExtendedProperty(updateTable, SmoUtil.DESCRIPTION_PROPERTY, description));
            }
            else
            {
                updateTable.ExtendedProperties[SmoUtil.DESCRIPTION_PROPERTY].Value = description;
                updateTable.ExtendedProperties[SmoUtil.DESCRIPTION_PROPERTY].Alter();
            }

            updateTable.Alter();

            EndAction(Resources.TableDescriptionEndAction);
        }

        /// <summary>
        /// Displays a Connection String Builder (DataLinks) dialog.
        /// 
        /// Credits:
        /// http://www.codeproject.com/cs/database/DataLinks.asp
        /// http://www.codeproject.com/cs/database/DataLinks.asp?df=100&forumid=33457&select=1560237#xx1560237xx
        /// 
        /// Required COM references:
        /// %PROGRAMFILES%\Microsoft.NET\Primary Interop Assemblies\adodb.dll
        /// %PROGRAMFILES%\Common Files\System\Ole DB\OLEDB32.DLL
        /// </summary>
        /// <param name="currentConnectionString">Previous database connection string</param>
        /// <returns>Selected connection string</returns>
        private string PromptForConnectionString(string currentConnectionString)
        {
            MSDASC.DataLinks dataLinks = new MSDASC.DataLinksClass();
            ADODB.Connection dialogConnection;
            string generatedConnectionString = string.Empty;

            if (currentConnectionString == String.Empty)
            {
                dialogConnection = (ADODB.Connection)dataLinks.PromptNew();
                generatedConnectionString = dialogConnection.ConnectionString.ToString();
            }
            else
            {
                dialogConnection = new ADODB.Connection();
                dialogConnection.Provider = "SQLOLEDB.1";
                ADODB.Property persistProperty = dialogConnection.Properties["Persist Security Info"];
                persistProperty.Value = true;

                dialogConnection.ConnectionString = currentConnectionString;
                dataLinks = new MSDASC.DataLinks();

                object objConn = dialogConnection;

                if (dataLinks.PromptEdit(ref objConn))
                {
                    generatedConnectionString = dialogConnection.ConnectionString.ToString();
                }
            }

            generatedConnectionString = generatedConnectionString.Replace("Provider=SQLOLEDB.1;", string.Empty);

            if
            (
                !generatedConnectionString.Contains("Integrated Security=SSPI")
                && !generatedConnectionString.Contains("Trusted_Connection=True")
                && !generatedConnectionString.Contains("Password=")
                && !generatedConnectionString.Contains("Pwd=")
            )

                // BSG: Updated for null check on Value not only Password Property.
                if (dialogConnection.Properties["Password"].Value != null)
                    generatedConnectionString += ";Password=" + dialogConnection.Properties["Password"].Value.ToString();

            return generatedConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        internal static string GetSql(string Name)
        {
            // Gets the current assembly.
            System.Reflection.Assembly Asm = System.Reflection.Assembly.GetExecutingAssembly();
            // Resources are named using a fully qualified name.
            Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);
            // Reads the contents of the embedded file.
            StreamReader reader = new StreamReader(strm);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Prompt the user to build a connection string and then set the connection
        /// </summary>
        private void SetConnectionString()
        {
            // Build the connection string
            string newConnectionString = PromptForConnectionString(this.txtConnectionString.Text);
            this.Refresh(); //Need to repaint form after dialog goes away.

            //TODO: Review this code
            // We may need to check the new and old value of the connection string but I'm commenting it out now because it is causing issues and no one is here to stop me
            // if (!string.IsNullOrEmpty(newConnectionString) && newConnectionString != sqlConnectionString)
            if (!string.IsNullOrEmpty(newConnectionString))
            {
                sqlConnectionString = newConnectionString;
            }
        }

        #endregion

        #region - Connect Database Tab Events -

        private void txtConnectionString_Leave(object sender, EventArgs e)
        {
            //Underlying setting will be automatically updated, but need to trigger refresh
            sqlConnectionString = txtConnectionString.Text;
        }

        private void txtConnectionString_DoubleClick(object sender, EventArgs e)
        {
            SetConnectionString();
        }

        private void btnSetConnectionString_Click(object sender, EventArgs e)
        {
            SetConnectionString();
        }

        private void btnAdvancedSettings_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageAdvancedSettings.ToString());
        }

        private void btnDocumentDatabase_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageDocumentDatabase.ToString());
        }

        #endregion

        #region - Advanced Settings Tab Events -

        private void txtAdditionalProperties_Leave(object sender, EventArgs e)
        {
            additionalProperties = txtAdditionalProperties.Text;
        }

        private void txtPrimaryKeyDescription_Leave(object sender, EventArgs e)
        {
            primaryKeyDescription = txtPrimaryKeyDescription.Text;
        }

        private void txtForeignKeyDescription_Leave(object sender, EventArgs e)
        {
            foreignKeyDescription = txtForeignKeyDescription.Text;
        }

        private void chkOverwriteDescriptions_CheckStateChanged(object sender, EventArgs e)
        {
            allowOverwrite = chkOverwriteDescriptions.Checked;
        }

        #endregion

        #region - Document Tab Events -

        private void txtConnectionString_TextChanged(object sender, EventArgs e)
        {
            btnConnect.Visible = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Underlying setting will be automatically updated, but need to trigger refresh
            sqlConnectionString = txtConnectionString.Text;
            btnConnect.Visible = false;
        }

        private void btnSetKeyDescriptions_Click(object sender, EventArgs e)
        {
            bool overwrite = chkOverwriteDescriptions.Checked;
            BeginAction(Resources.AdvanceSettingsKeyDescriptionsBeginAction, db.Tables.Count);

            foreach (Table table in db.Tables)
            {
                toolStripProgressBar.Value++;

                foreach (Column column in table.Columns)
                {
                    if (column.InPrimaryKey)
                        SetPropertyValue(table, SmoUtil.DESCRIPTION_PROPERTY, primaryKeyDescription, column, overwrite);
                    if (column.IsForeignKey)
                    {
                        foreach (ForeignKey fk in table.ForeignKeys)
                        {
                            if (fk.Columns.Contains(column.Name))
                            {
                                SetPropertyValue(table, SmoUtil.DESCRIPTION_PROPERTY, string.Format(foreignKeyDescription, fk.ReferencedTable), column, overwrite);
                                break;
                            }
                        }
                    }
                }
            }
            EndAction(Resources.AdvancedSettingsKeyDescriptonsEndAction);
        }

        #endregion

        #region - Export Tab Events --

        private void btnExport_Click(object sender, EventArgs e)
        {
            saveFileDialogExport.FileName = db.Name;
            saveFileDialogExport.Filter = "Excel (*.xls)|*.xls" +
                                        "|Excel Grouped (*.xls)|*.xls" +
                                        "|HTML (*.htm)|*.htm" +
                                        "|HTML Grouped (.htm)|.htm" +
                                        "|Word (*.doc)|*.doc" +
                                        "|Word Grouped (*.doc)|*.doc" +
                                        "|XML (*.xml)|*.xml" +
                                        "|T-SQL (*.sql)|*.sql";
            saveFileDialogExport.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialogExport.FileName))
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialogExport.FileName);
                    //Allow a little extra space on the progress bar for the XSL transform
                    BeginAction("Exporting to " + fileInfo.Name, (int)(db.Tables.Count * 1.1));
                    this.Refresh();
                    Exporter exporter;

                    switch (fileInfo.Extension)
                    {
                        case ".sql":
                            exporter = Exporter.SqlScriptExporter(server.Information);
                            break;
                        case ".doc":
                            if (saveFileDialogExport.FilterIndex == 6)
                            {
                                exporter = Exporter.WordExporter(true);
                            }
                            else
                            {
                                exporter = Exporter.WordExporter(false);
                            }
                            break;
                        case ".xls":
                            if (saveFileDialogExport.FilterIndex == 2)
                            {
                                exporter = Exporter.ExcelExporter(true);
                            }
                            else
                            {
                                exporter = Exporter.ExcelExporter(false);
                            }
                            break;
                        case ".htm":
                        case ".html":
                            if (saveFileDialogExport.FilterIndex == 4)
                            {
                                exporter = Exporter.HtmlExporter(true);
                            }
                            else
                            {
                                exporter = Exporter.HtmlExporter(false);
                            }
                            break;
                        case ".xml":
                            exporter = Exporter.XmlExporter();
                            break;
                        case "":
                            return;
                        default:
                            //Could move this check before exporting to XML.
                            MessageBox.Show(
                                "Export isn't supported for this filetype: " + fileInfo.Extension,
                                "Unsupported File Type",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                    }

                    exporter.Progressed += new EventHandler(ProgressUpdate);
                    exporter.Export(db, additionalPropertiesArray, fileInfo);

                    try
                    {
                        if (chkOpenFile.Checked)
                            System.Diagnostics.Process.Start(fileInfo.FullName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(Resources.ExportErrorGeneric);
                    }
                }
                finally
                {
                    EndAction(Resources.ExportEndAction);
                }
            }
        }

        #endregion

        #region - Import Tab Events -

        private void btnImport_Click(object sender, EventArgs e)
        {
            openFileDialogImport.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialogImport.FileName))
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(openFileDialogImport.FileName);
                    //Allow a little extra space on the progress bar for the XSL transform
                    BeginAction("Importing from " + fileInfo.Name, (int)(db.Tables.Count * 1.1));
                    this.Refresh();

                    switch (fileInfo.Extension)
                    {
                        case ".sql":
                            //Check script contains correct DDC tag
                            string script = fileInfo.OpenText().ReadToEnd();
                            if (script.IndexOf(Exporter.Identifier, StringComparison.InvariantCultureIgnoreCase) == -1)
                                throw new System.Exception(Resources.ImportErrorCanNotValidateScript);

                            //Execute SQL script - this command knows how to deal with GO separators
                            server.ConnectionContext.ExecuteNonQuery(script);
                            break;
                        case ".xml":
                            //Check doctype and tags to ensure DDC type
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(fileInfo.FullName);
                            if (!xmlDoc.DocumentType.Name.Equals(XmlExporter.Identifier, StringComparison.InvariantCultureIgnoreCase))
                                throw new System.Exception(Resources.ImportErrorUnsupportedVersion);

                            //Iterate and import
                            foreach (XmlNode tableNode in xmlDoc.SelectNodes("//documentation/tables/table"))
                            {
                                string tbl = "[" + tableNode.Attributes["schema"].Value + "].[" + tableNode.Attributes["name"].Value + "]";
                                Table currentTable = SmoUtil.GetTableByName(db, tbl);
                                SetTableDescription(currentTable, tableNode.Attributes["description"].Value);
                                foreach (XmlNode columnNode in tableNode.SelectNodes("column"))
                                {
                                    SetPropertyValue(currentTable, SmoUtil.DESCRIPTION_PROPERTY, columnNode.Attributes["description"].Value, columnNode.Attributes["name"].Value, true);
                                    foreach (XmlNode columnPropertyNode in columnNode.SelectNodes("property"))
                                    {
                                        SetPropertyValue(currentTable, columnPropertyNode.Attributes["name"].Value, columnPropertyNode.Attributes["value"].Value, columnNode.Attributes["name"].Value, true);
                                    }
                                }
                            }
                            break;
                    }
                    DocumentationSetup(sqlConnectionString);
                    EndAction(Resources.ImportEndAction);
                }
                catch (Exception ex)
                {
                    EndAction("ERROR: " + ex.Message);
                }
                finally
                {
                }
            }
        }

        #endregion

        #region - Status Bar Events -

        private void lnkException_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(connectionExceptionDetails);
        }

        #endregion

        #region - Menu Events -

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frmAbout = new About();
            frmAbout.Show();
        }

        private void connectToDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageConnect.ToString());
        }

        private void setAdditionalPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageAdvancedSettings.ToString());
        }

        private void importDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageImportDocumentation.ToString());
        }

        private void documentDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageDocumentDatabase.ToString());
        }

        private void exportDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageExportDocumentation.ToString());
        }

        private void additionalPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageAdvancedSettings.ToString());
        }

        private void autoFillKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageAdvancedSettings.ToString());
        }

        private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageDocumentDatabase.ToString());
            tabContainerObjects.SelectTab(tabpages.tabPageTables.ToString());
        }

        private void viewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabContainerMain.SelectTab(tabpages.tabPageDocumentDatabase.ToString());
            tabContainerObjects.SelectTab(tabpages.tabPageViews.ToString());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region - Tab Navigation -

        private void btnNext_Click(object sender, EventArgs e)
        {
            int curIndex = tabContainerMain.SelectedIndex;
            tabContainerMain.SelectTab(curIndex + 1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            int curIndex = tabContainerMain.SelectedIndex;
            tabContainerMain.SelectTab(curIndex - 1);
        }

        private void tabContainerMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBack.Visible = !(tabContainerMain.SelectedIndex == 0);
            btnNext.Visible = !(tabContainerMain.SelectedIndex == (tabContainerMain.TabCount - 1));
        }

        #endregion

        #region - Tables Documentation -

        private void SetupTableDocumentation()
        {
            ddlTables.Items.Clear();
            dgvColumns.DataSource = null;

            // Display all non-sysobject tables to be documented
            foreach (Table table in db.Tables)
            {
                if (!table.IsSystemObject)
                {
                    ddlTables.Items.Add(table.ToString());
                }
            }

            // Ultimately, display the selected table fields in the grid
            if (ddlTables.Items.Count > 0)
            {
                if (ddlTables.SelectedIndex == 0)
                    FillSelectedTableToDocument();
                else
                    ddlTables.SelectedIndex = 0;
            }
        }

        private void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSelectedTableToDocument();
        }

        private void txtTableDescription_Leave(object sender, EventArgs e)
        {
            SetTableDescription(txtTableDescription.Text);
        }

        private void dgvColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string tableColumnName = dgvColumns["Column", e.RowIndex].Value.ToString();
            string gridPropertyName = dgvColumns.Columns[e.ColumnIndex].Name;
            string databasePropertyName = (gridPropertyName == "Description") ? SmoUtil.DESCRIPTION_PROPERTY : gridPropertyName;
            string value = dgvColumns[e.ColumnIndex, e.RowIndex].Value.ToString();
            SetPropertyValue(this.table, databasePropertyName, value, tableColumnName, true);
        }

        private void chkExcludedTable_Click(object sender, EventArgs e)
        {
            ExcludedObject eo = new ExcludedObject(this.table);
            bool exists = Properties.Settings.Default.ExcludedObjects.Exists(obj => obj == eo);

            if (chkExcludedTable.Checked)
            {
                if (!exists)
                {
                    Properties.Settings.Default.ExcludedObjects.Add(eo);
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                if (exists)
                {
                    Properties.Settings.Default.ExcludedObjects.Remove(eo);
                    Properties.Settings.Default.Save();
                }
            }
        }

        #endregion

        #region - Views Documentation -

        private void SetupViewDocumentation()
        {
            ddlViews.Items.Clear();
            //dgvColumns.DataSource = null;

            // Display all non-sysobject tables to be documented
            foreach (Microsoft.SqlServer.Management.Smo.View view in db.Views)
            {
                if (!view.IsSystemObject)
                {
                    ddlViews.Items.Add(view.ToString());
                }
            }

            // Ultimately, display the selected table fields in the grid
            if (ddlViews.Items.Count > 0)
            {
                if (ddlViews.SelectedIndex == 0)
                {
                    ;//FillSelectedTableToDocument();
                }
                else
                {
                    ddlViews.SelectedIndex = 0;
                }
            }
        }

        #endregion

        #region Updater

        private bool UpdateAvailable()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();

                return info.UpdateAvailable;
            }

            return false;
        }

        #endregion

        #region Update Checker

        private enum UpdateStatuses
        {
            NoUpdateAvailable,
            UpdateAvailable,
            UpdateRequired,
            NotDeployedViaClickOnce,
            DeploymentDownloadException,
            InvalidDeploymentException,
            InvalidOperationException
        }

        private void bgwUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCheckInfo info = null;

            // Check if the application was deployed via ClickOnce.
            if (!ApplicationDeployment.IsNetworkDeployed)
            {
                e.Result = UpdateStatuses.NotDeployedViaClickOnce;
                return;
            }

            ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;

            try
            {
                info = updateCheck.CheckForDetailedUpdate();
            }
            catch (DeploymentDownloadException)
            {
                e.Result = UpdateStatuses.DeploymentDownloadException;
                return;
            }
            catch (InvalidDeploymentException)
            {
                e.Result = UpdateStatuses.InvalidDeploymentException;
                return;
            }
            catch (InvalidOperationException)
            {
                e.Result = UpdateStatuses.InvalidOperationException;
                return;
            }

            if (info.UpdateAvailable)
            {
                if (info.IsUpdateRequired)
                {
                    e.Result = UpdateStatuses.UpdateRequired;
                }
                else
                {
                    e.Result = UpdateStatuses.UpdateAvailable;
                }
            }
            else
            {
                e.Result = UpdateStatuses.NoUpdateAvailable;
            }
        }

        private void bgwUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch ((UpdateStatuses)e.Result)
            {
                case UpdateStatuses.UpdateAvailable:
                    updateAvailableToolStripMenuItem.Visible = true;                    
                    break;
                case UpdateStatuses.UpdateRequired:
                    updateAvailableToolStripMenuItem.Visible = true;
                    MessageBox.Show(Resources.RequiredUpdateAvailable, Resources.UpdateAvailable, MessageBoxButtons.OK);
                    UpdateApplication();
                    break;                
            }
        }

        private void updateAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.UpdateApplicationNow, Resources.UpdateAvailable, MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                UpdateApplication(); 
            }            
        }

        private void UpdateApplication()
        {
            try
            {
                ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
                updateCheck.Update();
                MessageBox.Show(Resources.ApplicationUpdated);
                Application.Restart();
            }
            catch (DeploymentDownloadException dde)
            {
                MessageBox.Show(string.Format(Resources.DeploymentDownloadExceptionMessage,  dde));
                return;
            }   
        }

        #endregion
    }
}