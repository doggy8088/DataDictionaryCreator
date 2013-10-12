using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Linq;

namespace DataDictionaryCreator
{
    public abstract class Exporter
    {
        public static string Identifier = "DATA DICTIONARY CREATOR";
        public static Exporter WordExporter(bool isGrouped)
        {
            if (isGrouped)
            {
                return new XsltExporter("wordMLOutput_Grouped.xslt");
            }
            else
            {
                return new XsltExporter("wordMLOutput.xslt");
            }            
        }

        public static Exporter XmlExporter()
        {
            return new XmlExporter();
        }

        public static Exporter ExcelExporter(bool isGrouped)
        {
            if (isGrouped)
            {
                return new XsltExporter("excelOutput_Grouped.xslt");
            }
            else
            {
                return new XsltExporter("excelOutput.xslt");
            }
        }

        public static Exporter HtmlExporter(bool isGrouped)
        {
            if (isGrouped)
            {
                return new XsltExporter("htmlOutput_Grouped.xslt");
            }
            else
            {
                return new XsltExporter("htmlOutput.xslt");
            }
        }

        public static Exporter SqlScriptExporter(Information serverInformation)
        {
            if (serverInformation.Version.Major == 9)
                return new XsltExporter("sql2005Output.xslt");
            else
                return new XsltExporter("sql2000Output.xslt");
        }

        public event EventHandler Progressed;
        private Database database;
        private string[] additionalProperties;

        public Exporter()
        {
        }

        protected abstract void Initialize(Stream stream);
        protected abstract void BeginExport(Database database, string[] additionalProperties);
        protected abstract void EndColumn();
        protected abstract void EndTable();
        protected abstract void EndExport();
        protected abstract void ExportColumnProperties(Table table, Column column);
        protected abstract void ExportColumnExtendedProperty(Table table, Column column, string property);
        protected abstract void ExportTableProperties(Table table);
        protected abstract void ExportTableExtendedProperty(Table table, string property);

        protected virtual void SaveTo(MemoryStream stream, string fileName)
        {
            FileStream fs = File.OpenWrite(fileName);
            fs.Write(stream.GetBuffer(), 0, (int)stream.Length);
            fs.Close();
        }

        public void Export(Database database, string[] additionalProperties, FileInfo exportTo)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                this.database = database;
                this.additionalProperties = additionalProperties;

                Initialize(stream);
                BeginExport(database, additionalProperties);

                foreach (Table table in database.Tables)
                {

                    if (null != Progressed)
                    {
                        Progressed(this, EventArgs.Empty);
                    }

                    if (table.IsSystemObject)
                    {
                        continue;
                    }

                    if (Properties.Settings.Default.ExcludedObjects.Exists(obj => obj == new ExcludedObject(table)))
                    {
                        continue;
                    }

                    ExportTableProperties(table);

                    foreach (string property in additionalProperties)
                    {
                        ExportTableExtendedProperty(table, property);
                    }

                    foreach (Column column in table.Columns)
                    {
                        ExportColumnProperties(table, column);

                        foreach (string property in additionalProperties)
                        {
                            ExportColumnExtendedProperty(table, column, property);
                        }

                        EndColumn();
                    }
                    EndTable();
                }
                EndExport();
                stream.Position = 0;
                if (exportTo.Exists)
                    exportTo.Delete();
                SaveTo(stream, exportTo.FullName);
            }
        }
    }
}
