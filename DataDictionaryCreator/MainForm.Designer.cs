namespace DataDictionaryCreator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            DataDictionaryCreator.Properties.Settings settings1 = new DataDictionaryCreator.Properties.Settings();
            DataDictionaryCreator.Properties.Settings settings2 = new DataDictionaryCreator.Properties.Settings();
            DataDictionaryCreator.Properties.Settings settings3 = new DataDictionaryCreator.Properties.Settings();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.txtForeignKeyDescription = new System.Windows.Forms.TextBox();
            this.txtPrimaryKeyDescription = new System.Windows.Forms.TextBox();
            this.chkOverwriteDescriptions = new System.Windows.Forms.CheckBox();
            this.txtAdditionalProperties = new System.Windows.Forms.TextBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAdditionalPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoFillKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lnkException = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tabPageDocumentDatabase = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.tabContainerObjects = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.chkExcludedTable = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTableDescription = new System.Windows.Forms.TextBox();
            this.ddlTables = new System.Windows.Forms.ComboBox();
            this.tabPageViews = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtViewDescription = new System.Windows.Forms.TextBox();
            this.ddlViews = new System.Windows.Forms.ComboBox();
            this.tabPageImportDocumentation = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblImport = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabPageExportDocumentation = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.chkOpenFile = new System.Windows.Forms.CheckBox();
            this.lblExportInfo = new System.Windows.Forms.Label();
            this.tabPageAdvancedSettings = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetKeyDescriptions = new System.Windows.Forms.Button();
            this.lblAutoFill = new System.Windows.Forms.Label();
            this.tabPageConnect = new System.Windows.Forms.TabPage();
            this.lblConnectionSuccess = new System.Windows.Forms.Label();
            this.btnDocumentDatabase = new System.Windows.Forms.Button();
            this.btnAdvancedSettings = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSetConnectionString = new System.Windows.Forms.Button();
            this.lblConnectDatabaseInstructions = new System.Windows.Forms.Label();
            this.tabContainerMain = new System.Windows.Forms.TabControl();
            this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogImportSample = new System.Windows.Forms.OpenFileDialog();
            this.bgwUpdater = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPageDocumentDatabase.SuspendLayout();
            this.tabContainerObjects.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.tabPageViews.SuspendLayout();
            this.tabPageImportDocumentation.SuspendLayout();
            this.tabPageExportDocumentation.SuspendLayout();
            this.tabPageAdvancedSettings.SuspendLayout();
            this.tabPageConnect.SuspendLayout();
            this.tabContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialogExport
            // 
            resources.ApplyResources(this.saveFileDialogExport, "saveFileDialogExport");
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.toolTip.SetToolTip(this.btnExport, resources.GetString("btnExport.ToolTip"));
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtForeignKeyDescription
            // 
            settings1.ADDITIONAL_PROPERTIES = "";
            settings1.ALLOW_OVERWRITE = true;
            settings1.ExcludedObjects = null;
            settings1.FOREIGN_KEY_DESCRIPTION = "Link to {0} table";
            settings1.PRIMARY_KEY_DESCRIPTION = "Primary key";
            settings1.SettingsKey = "";
            settings1.SQL_CONNECTION_STRING = "Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=Northwind;Dat" +
                "a Source=(local)";
            this.txtForeignKeyDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings1, "FOREIGN_KEY_DESCRIPTION", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.txtForeignKeyDescription, "txtForeignKeyDescription");
            this.txtForeignKeyDescription.Name = "txtForeignKeyDescription";
            this.txtForeignKeyDescription.Text = settings1.FOREIGN_KEY_DESCRIPTION;
            this.toolTip.SetToolTip(this.txtForeignKeyDescription, resources.GetString("txtForeignKeyDescription.ToolTip"));
            this.txtForeignKeyDescription.Leave += new System.EventHandler(this.txtForeignKeyDescription_Leave);
            // 
            // txtPrimaryKeyDescription
            // 
            settings2.ADDITIONAL_PROPERTIES = "";
            settings2.ALLOW_OVERWRITE = true;
            settings2.ExcludedObjects = null;
            settings2.FOREIGN_KEY_DESCRIPTION = "Link to {0} table";
            settings2.PRIMARY_KEY_DESCRIPTION = "Primary key";
            settings2.SettingsKey = "";
            settings2.SQL_CONNECTION_STRING = "Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=Northwind;Dat" +
                "a Source=(local)";
            this.txtPrimaryKeyDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", settings2, "PRIMARY_KEY_DESCRIPTION", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.txtPrimaryKeyDescription, "txtPrimaryKeyDescription");
            this.txtPrimaryKeyDescription.Name = "txtPrimaryKeyDescription";
            this.txtPrimaryKeyDescription.Text = settings2.PRIMARY_KEY_DESCRIPTION;
            this.toolTip.SetToolTip(this.txtPrimaryKeyDescription, resources.GetString("txtPrimaryKeyDescription.ToolTip"));
            this.txtPrimaryKeyDescription.Leave += new System.EventHandler(this.txtPrimaryKeyDescription_Leave);
            // 
            // chkOverwriteDescriptions
            // 
            resources.ApplyResources(this.chkOverwriteDescriptions, "chkOverwriteDescriptions");
            this.chkOverwriteDescriptions.BackColor = System.Drawing.Color.Transparent;
            settings3.ADDITIONAL_PROPERTIES = "";
            settings3.ALLOW_OVERWRITE = true;
            settings3.ExcludedObjects = null;
            settings3.FOREIGN_KEY_DESCRIPTION = "Link to {0} table";
            settings3.PRIMARY_KEY_DESCRIPTION = "Primary key";
            settings3.SettingsKey = "";
            settings3.SQL_CONNECTION_STRING = "Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=Northwind;Dat" +
                "a Source=(local)";
            this.chkOverwriteDescriptions.Checked = settings3.ALLOW_OVERWRITE;
            this.chkOverwriteDescriptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverwriteDescriptions.DataBindings.Add(new System.Windows.Forms.Binding("Checked", settings3, "ALLOW_OVERWRITE", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkOverwriteDescriptions.Name = "chkOverwriteDescriptions";
            this.toolTip.SetToolTip(this.chkOverwriteDescriptions, resources.GetString("chkOverwriteDescriptions.ToolTip"));
            this.chkOverwriteDescriptions.UseVisualStyleBackColor = false;
            this.chkOverwriteDescriptions.CheckStateChanged += new System.EventHandler(this.chkOverwriteDescriptions_CheckStateChanged);
            // 
            // txtAdditionalProperties
            // 
            resources.ApplyResources(this.txtAdditionalProperties, "txtAdditionalProperties");
            this.txtAdditionalProperties.Name = "txtAdditionalProperties";
            this.toolTip.SetToolTip(this.txtAdditionalProperties, resources.GetString("txtAdditionalProperties.ToolTip"));
            this.txtAdditionalProperties.Leave += new System.EventHandler(this.txtAdditionalProperties_Leave);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.BackColor = System.Drawing.Color.White;
            this.txtConnectionString.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::DataDictionaryCreator.Properties.Settings.Default, "SQL_CONNECTION_STRING", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.txtConnectionString, "txtConnectionString");
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Text = global::DataDictionaryCreator.Properties.Settings.Default.SQL_CONNECTION_STRING;
            this.toolTip.SetToolTip(this.txtConnectionString, resources.GetString("txtConnectionString.ToolTip"));
            this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
            this.txtConnectionString.DoubleClick += new System.EventHandler(this.txtConnectionString_DoubleClick);
            this.txtConnectionString.Leave += new System.EventHandler(this.txtConnectionString_Leave);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            this.toolStripStatusLabel.Spring = true;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            this.toolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.updateAvailableToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToDatabaseToolStripMenuItem,
            this.setAdditionalPropertiesToolStripMenuItem,
            this.documentDatabaseToolStripMenuItem,
            this.exportDocumentationToolStripMenuItem,
            this.importDocumentationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // connectToDatabaseToolStripMenuItem
            // 
            this.connectToDatabaseToolStripMenuItem.Name = "connectToDatabaseToolStripMenuItem";
            resources.ApplyResources(this.connectToDatabaseToolStripMenuItem, "connectToDatabaseToolStripMenuItem");
            this.connectToDatabaseToolStripMenuItem.Click += new System.EventHandler(this.connectToDatabaseToolStripMenuItem_Click);
            // 
            // setAdditionalPropertiesToolStripMenuItem
            // 
            this.setAdditionalPropertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionalPropertiesToolStripMenuItem,
            this.autoFillKeysToolStripMenuItem});
            this.setAdditionalPropertiesToolStripMenuItem.Name = "setAdditionalPropertiesToolStripMenuItem";
            resources.ApplyResources(this.setAdditionalPropertiesToolStripMenuItem, "setAdditionalPropertiesToolStripMenuItem");
            this.setAdditionalPropertiesToolStripMenuItem.Click += new System.EventHandler(this.setAdditionalPropertiesToolStripMenuItem_Click);
            // 
            // additionalPropertiesToolStripMenuItem
            // 
            this.additionalPropertiesToolStripMenuItem.Name = "additionalPropertiesToolStripMenuItem";
            resources.ApplyResources(this.additionalPropertiesToolStripMenuItem, "additionalPropertiesToolStripMenuItem");
            this.additionalPropertiesToolStripMenuItem.Click += new System.EventHandler(this.additionalPropertiesToolStripMenuItem_Click);
            // 
            // autoFillKeysToolStripMenuItem
            // 
            this.autoFillKeysToolStripMenuItem.Name = "autoFillKeysToolStripMenuItem";
            resources.ApplyResources(this.autoFillKeysToolStripMenuItem, "autoFillKeysToolStripMenuItem");
            this.autoFillKeysToolStripMenuItem.Click += new System.EventHandler(this.autoFillKeysToolStripMenuItem_Click);
            // 
            // documentDatabaseToolStripMenuItem
            // 
            this.documentDatabaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablesToolStripMenuItem,
            this.viewsToolStripMenuItem});
            this.documentDatabaseToolStripMenuItem.Name = "documentDatabaseToolStripMenuItem";
            resources.ApplyResources(this.documentDatabaseToolStripMenuItem, "documentDatabaseToolStripMenuItem");
            this.documentDatabaseToolStripMenuItem.Click += new System.EventHandler(this.documentDatabaseToolStripMenuItem_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            resources.ApplyResources(this.tablesToolStripMenuItem, "tablesToolStripMenuItem");
            this.tablesToolStripMenuItem.Click += new System.EventHandler(this.tablesToolStripMenuItem_Click);
            // 
            // viewsToolStripMenuItem
            // 
            this.viewsToolStripMenuItem.Name = "viewsToolStripMenuItem";
            resources.ApplyResources(this.viewsToolStripMenuItem, "viewsToolStripMenuItem");
            this.viewsToolStripMenuItem.Click += new System.EventHandler(this.viewsToolStripMenuItem_Click);
            // 
            // exportDocumentationToolStripMenuItem
            // 
            this.exportDocumentationToolStripMenuItem.Name = "exportDocumentationToolStripMenuItem";
            resources.ApplyResources(this.exportDocumentationToolStripMenuItem, "exportDocumentationToolStripMenuItem");
            this.exportDocumentationToolStripMenuItem.Click += new System.EventHandler(this.exportDocumentationToolStripMenuItem_Click);
            // 
            // importDocumentationToolStripMenuItem
            // 
            this.importDocumentationToolStripMenuItem.Name = "importDocumentationToolStripMenuItem";
            resources.ApplyResources(this.importDocumentationToolStripMenuItem, "importDocumentationToolStripMenuItem");
            this.importDocumentationToolStripMenuItem.Click += new System.EventHandler(this.importDocumentationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // updateAvailableToolStripMenuItem
            // 
            this.updateAvailableToolStripMenuItem.Name = "updateAvailableToolStripMenuItem";
            resources.ApplyResources(this.updateAvailableToolStripMenuItem, "updateAvailableToolStripMenuItem");
            this.updateAvailableToolStripMenuItem.Click += new System.EventHandler(this.updateAvailableToolStripMenuItem_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lnkException
            // 
            resources.ApplyResources(this.lnkException, "lnkException");
            this.lnkException.Name = "lnkException";
            this.lnkException.TabStop = true;
            this.lnkException.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkException_LinkClicked);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabPageDocumentDatabase
            // 
            this.tabPageDocumentDatabase.Controls.Add(this.label17);
            this.tabPageDocumentDatabase.Controls.Add(this.tabContainerObjects);
            resources.ApplyResources(this.tabPageDocumentDatabase, "tabPageDocumentDatabase");
            this.tabPageDocumentDatabase.Name = "tabPageDocumentDatabase";
            this.tabPageDocumentDatabase.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label17.Name = "label17";
            // 
            // tabContainerObjects
            // 
            resources.ApplyResources(this.tabContainerObjects, "tabContainerObjects");
            this.tabContainerObjects.Controls.Add(this.tabPageTables);
            this.tabContainerObjects.Controls.Add(this.tabPageViews);
            this.tabContainerObjects.Name = "tabContainerObjects";
            this.tabContainerObjects.SelectedIndex = 0;
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.chkExcludedTable);
            this.tabPageTables.Controls.Add(this.panel1);
            this.tabPageTables.Controls.Add(this.label5);
            this.tabPageTables.Controls.Add(this.label4);
            this.tabPageTables.Controls.Add(this.txtTableDescription);
            this.tabPageTables.Controls.Add(this.ddlTables);
            resources.ApplyResources(this.tabPageTables, "tabPageTables");
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // chkExcludedTable
            // 
            resources.ApplyResources(this.chkExcludedTable, "chkExcludedTable");
            this.chkExcludedTable.Name = "chkExcludedTable";
            this.chkExcludedTable.UseVisualStyleBackColor = true;
            this.chkExcludedTable.Click += new System.EventHandler(this.chkExcludedTable_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.dgvColumns);
            this.panel1.Name = "panel1";
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AllowUserToOrderColumns = true;
            this.dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColumns.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvColumns.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvColumns.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvColumns.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvColumns, "dgvColumns");
            this.dgvColumns.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvColumns.GridColor = System.Drawing.Color.GhostWhite;
            this.dgvColumns.Name = "dgvColumns";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumns.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColumns.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumns.RowTemplate.Height = 44;
            this.dgvColumns.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvColumns_CellValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtTableDescription
            // 
            resources.ApplyResources(this.txtTableDescription, "txtTableDescription");
            this.txtTableDescription.Name = "txtTableDescription";
            this.txtTableDescription.Leave += new System.EventHandler(this.txtTableDescription_Leave);
            // 
            // ddlTables
            // 
            this.ddlTables.FormattingEnabled = true;
            resources.ApplyResources(this.ddlTables, "ddlTables");
            this.ddlTables.Name = "ddlTables";
            this.ddlTables.SelectedIndexChanged += new System.EventHandler(this.ddlTables_SelectedIndexChanged);
            // 
            // tabPageViews
            // 
            this.tabPageViews.Controls.Add(this.label18);
            this.tabPageViews.Controls.Add(this.label19);
            this.tabPageViews.Controls.Add(this.txtViewDescription);
            this.tabPageViews.Controls.Add(this.ddlViews);
            resources.ApplyResources(this.tabPageViews, "tabPageViews");
            this.tabPageViews.Name = "tabPageViews";
            this.tabPageViews.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // txtViewDescription
            // 
            resources.ApplyResources(this.txtViewDescription, "txtViewDescription");
            this.txtViewDescription.Name = "txtViewDescription";
            // 
            // ddlViews
            // 
            this.ddlViews.FormattingEnabled = true;
            resources.ApplyResources(this.ddlViews, "ddlViews");
            this.ddlViews.Name = "ddlViews";
            // 
            // tabPageImportDocumentation
            // 
            this.tabPageImportDocumentation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageImportDocumentation.Controls.Add(this.label13);
            this.tabPageImportDocumentation.Controls.Add(this.label12);
            this.tabPageImportDocumentation.Controls.Add(this.lblImport);
            this.tabPageImportDocumentation.Controls.Add(this.btnImport);
            resources.ApplyResources(this.tabPageImportDocumentation, "tabPageImportDocumentation");
            this.tabPageImportDocumentation.Name = "tabPageImportDocumentation";
            this.tabPageImportDocumentation.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Name = "label12";
            // 
            // lblImport
            // 
            resources.ApplyResources(this.lblImport, "lblImport");
            this.lblImport.BackColor = System.Drawing.Color.Transparent;
            this.lblImport.Name = "lblImport";
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tabPageExportDocumentation
            // 
            this.tabPageExportDocumentation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageExportDocumentation.Controls.Add(this.label16);
            this.tabPageExportDocumentation.Controls.Add(this.label15);
            this.tabPageExportDocumentation.Controls.Add(this.label14);
            this.tabPageExportDocumentation.Controls.Add(this.chkOpenFile);
            this.tabPageExportDocumentation.Controls.Add(this.lblExportInfo);
            this.tabPageExportDocumentation.Controls.Add(this.btnExport);
            resources.ApplyResources(this.tabPageExportDocumentation, "tabPageExportDocumentation");
            this.tabPageExportDocumentation.Name = "tabPageExportDocumentation";
            this.tabPageExportDocumentation.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Name = "label14";
            // 
            // chkOpenFile
            // 
            resources.ApplyResources(this.chkOpenFile, "chkOpenFile");
            this.chkOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.chkOpenFile.Checked = true;
            this.chkOpenFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenFile.Name = "chkOpenFile";
            this.chkOpenFile.UseVisualStyleBackColor = false;
            // 
            // lblExportInfo
            // 
            resources.ApplyResources(this.lblExportInfo, "lblExportInfo");
            this.lblExportInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblExportInfo.Name = "lblExportInfo";
            // 
            // tabPageAdvancedSettings
            // 
            this.tabPageAdvancedSettings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageAdvancedSettings.Controls.Add(this.label10);
            this.tabPageAdvancedSettings.Controls.Add(this.label2);
            this.tabPageAdvancedSettings.Controls.Add(this.label1);
            this.tabPageAdvancedSettings.Controls.Add(this.label9);
            this.tabPageAdvancedSettings.Controls.Add(this.label8);
            this.tabPageAdvancedSettings.Controls.Add(this.label7);
            this.tabPageAdvancedSettings.Controls.Add(this.label6);
            this.tabPageAdvancedSettings.Controls.Add(this.label3);
            this.tabPageAdvancedSettings.Controls.Add(this.txtAdditionalProperties);
            this.tabPageAdvancedSettings.Controls.Add(this.txtPrimaryKeyDescription);
            this.tabPageAdvancedSettings.Controls.Add(this.txtForeignKeyDescription);
            this.tabPageAdvancedSettings.Controls.Add(this.btnSetKeyDescriptions);
            this.tabPageAdvancedSettings.Controls.Add(this.chkOverwriteDescriptions);
            this.tabPageAdvancedSettings.Controls.Add(this.lblAutoFill);
            resources.ApplyResources(this.tabPageAdvancedSettings, "tabPageAdvancedSettings");
            this.tabPageAdvancedSettings.Name = "tabPageAdvancedSettings";
            this.tabPageAdvancedSettings.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Name = "label10";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Name = "label6";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Name = "label3";
            // 
            // btnSetKeyDescriptions
            // 
            resources.ApplyResources(this.btnSetKeyDescriptions, "btnSetKeyDescriptions");
            this.btnSetKeyDescriptions.Name = "btnSetKeyDescriptions";
            this.btnSetKeyDescriptions.UseVisualStyleBackColor = true;
            this.btnSetKeyDescriptions.Click += new System.EventHandler(this.btnSetKeyDescriptions_Click);
            // 
            // lblAutoFill
            // 
            resources.ApplyResources(this.lblAutoFill, "lblAutoFill");
            this.lblAutoFill.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoFill.Name = "lblAutoFill";
            // 
            // tabPageConnect
            // 
            this.tabPageConnect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageConnect.Controls.Add(this.lblConnectionSuccess);
            this.tabPageConnect.Controls.Add(this.btnDocumentDatabase);
            this.tabPageConnect.Controls.Add(this.btnAdvancedSettings);
            this.tabPageConnect.Controls.Add(this.btnConnect);
            this.tabPageConnect.Controls.Add(this.label11);
            this.tabPageConnect.Controls.Add(this.txtConnectionString);
            this.tabPageConnect.Controls.Add(this.btnSetConnectionString);
            this.tabPageConnect.Controls.Add(this.lblConnectDatabaseInstructions);
            resources.ApplyResources(this.tabPageConnect, "tabPageConnect");
            this.tabPageConnect.Name = "tabPageConnect";
            this.tabPageConnect.UseVisualStyleBackColor = true;
            // 
            // lblConnectionSuccess
            // 
            this.lblConnectionSuccess.AutoEllipsis = true;
            this.lblConnectionSuccess.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblConnectionSuccess, "lblConnectionSuccess");
            this.lblConnectionSuccess.Name = "lblConnectionSuccess";
            // 
            // btnDocumentDatabase
            // 
            resources.ApplyResources(this.btnDocumentDatabase, "btnDocumentDatabase");
            this.btnDocumentDatabase.Name = "btnDocumentDatabase";
            this.btnDocumentDatabase.UseVisualStyleBackColor = true;
            this.btnDocumentDatabase.Click += new System.EventHandler(this.btnDocumentDatabase_Click);
            // 
            // btnAdvancedSettings
            // 
            resources.ApplyResources(this.btnAdvancedSettings, "btnAdvancedSettings");
            this.btnAdvancedSettings.Name = "btnAdvancedSettings";
            this.btnAdvancedSettings.UseVisualStyleBackColor = true;
            this.btnAdvancedSettings.Click += new System.EventHandler(this.btnAdvancedSettings_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label11.Name = "label11";
            // 
            // btnSetConnectionString
            // 
            this.btnSetConnectionString.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSetConnectionString, "btnSetConnectionString");
            this.btnSetConnectionString.Name = "btnSetConnectionString";
            this.btnSetConnectionString.UseVisualStyleBackColor = true;
            this.btnSetConnectionString.Click += new System.EventHandler(this.btnSetConnectionString_Click);
            // 
            // lblConnectDatabaseInstructions
            // 
            this.lblConnectDatabaseInstructions.AutoEllipsis = true;
            resources.ApplyResources(this.lblConnectDatabaseInstructions, "lblConnectDatabaseInstructions");
            this.lblConnectDatabaseInstructions.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectDatabaseInstructions.Name = "lblConnectDatabaseInstructions";
            // 
            // tabContainerMain
            // 
            resources.ApplyResources(this.tabContainerMain, "tabContainerMain");
            this.tabContainerMain.Controls.Add(this.tabPageConnect);
            this.tabContainerMain.Controls.Add(this.tabPageAdvancedSettings);
            this.tabContainerMain.Controls.Add(this.tabPageDocumentDatabase);
            this.tabContainerMain.Controls.Add(this.tabPageExportDocumentation);
            this.tabContainerMain.Controls.Add(this.tabPageImportDocumentation);
            this.tabContainerMain.Name = "tabContainerMain";
            this.tabContainerMain.SelectedIndex = 0;
            this.tabContainerMain.SelectedIndexChanged += new System.EventHandler(this.tabContainerMain_SelectedIndexChanged);
            // 
            // openFileDialogImport
            // 
            resources.ApplyResources(this.openFileDialogImport, "openFileDialogImport");
            // 
            // openFileDialogImportSample
            // 
            this.openFileDialogImportSample.FileName = "ExcelSample.csv";
            resources.ApplyResources(this.openFileDialogImportSample, "openFileDialogImportSample");
            // 
            // bgwUpdater
            // 
            this.bgwUpdater.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdater_DoWork);
            this.bgwUpdater.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdater_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lnkException);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tabContainerMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageDocumentDatabase.ResumeLayout(false);
            this.tabPageDocumentDatabase.PerformLayout();
            this.tabContainerObjects.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tabPageTables.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.tabPageViews.ResumeLayout(false);
            this.tabPageViews.PerformLayout();
            this.tabPageImportDocumentation.ResumeLayout(false);
            this.tabPageImportDocumentation.PerformLayout();
            this.tabPageExportDocumentation.ResumeLayout(false);
            this.tabPageExportDocumentation.PerformLayout();
            this.tabPageAdvancedSettings.ResumeLayout(false);
            this.tabPageAdvancedSettings.PerformLayout();
            this.tabPageConnect.ResumeLayout(false);
            this.tabPageConnect.PerformLayout();
            this.tabContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setAdditionalPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoFillKeysToolStripMenuItem;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.LinkLabel lnkException;
        private System.Windows.Forms.OpenFileDialog openFileDialogImportSample;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPageDocumentDatabase;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabControl tabContainerObjects;
        private System.Windows.Forms.TabPage tabPageViews;
        private System.Windows.Forms.TabPage tabPageImportDocumentation;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblImport;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tabPageExportDocumentation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkOpenFile;
        private System.Windows.Forms.Label lblExportInfo;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tabPageAdvancedSettings;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAdditionalProperties;
        private System.Windows.Forms.TextBox txtPrimaryKeyDescription;
        private System.Windows.Forms.TextBox txtForeignKeyDescription;
        private System.Windows.Forms.Button btnSetKeyDescriptions;
        private System.Windows.Forms.CheckBox chkOverwriteDescriptions;
        private System.Windows.Forms.Label lblAutoFill;
        private System.Windows.Forms.TabPage tabPageConnect;
        private System.Windows.Forms.Label lblConnectionSuccess;
        private System.Windows.Forms.Button btnDocumentDatabase;
        private System.Windows.Forms.Button btnAdvancedSettings;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnSetConnectionString;
        private System.Windows.Forms.Label lblConnectDatabaseInstructions;
        private System.Windows.Forms.TabControl tabContainerMain;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTableDescription;
        private System.Windows.Forms.ComboBox ddlTables;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtViewDescription;
        private System.Windows.Forms.ComboBox ddlViews;
        private System.Windows.Forms.CheckBox chkExcludedTable;
        private System.Windows.Forms.ToolStripMenuItem updateAvailableToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgwUpdater;

    }
}

