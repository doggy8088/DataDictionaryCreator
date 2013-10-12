using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace DataDictionaryCreator
{
	/// <summary>
	/// Description of XmlExporter.
	/// </summary>
	public class XmlExporter : Exporter
	{
        new public static string Identifier = "DataDictionaryCreator";
		private XmlTextWriter writer = null;
		protected override void BeginExport(Database database, string[] additionalProperties)
		{
            writer.WriteStartDocument();
            writer.WriteDocType("DataDictionaryCreator", null, null, null);
            writer.WriteComment("Contains data dictionary information exported from Data Dictionary Creator");
            writer.WriteComment("More information available via http://tools.veloc-it.com");
            writer.WriteStartElement("documentation");
            writer.WriteAttributeString("database", database.Name);
            writer.WriteAttributeString("generator", "Data Dictionary Creator");
            writer.WriteAttributeString("generator_version", Application.ProductVersion);
            writer.WriteAttributeString("date", DateTime.Now.ToString());
            writer.WriteAttributeString("additionalPropertyCount", additionalProperties.Length.ToString());
            writer.WriteStartElement("tables");
        }
		
		protected override void EndColumn()
		{
            writer.WriteEndElement(); //column
		}
		
		protected override void EndExport()
		{
            writer.WriteEndElement(); //tables
            writer.WriteEndElement(); //documentation
            writer.WriteEndDocument();
            writer.Flush();
		}
		
		protected override void EndTable()
		{
            writer.WriteEndElement(); //column
		}
		
		protected override void ExportColumnExtendedProperty(Table table, Column column, string property)
		{
            writer.WriteStartElement("property");
            writer.WriteAttributeString("name", property);
            if (column.ExtendedProperties.Contains(property))
                writer.WriteAttributeString("value", column.ExtendedProperties[property].Value.ToString());
            else
                writer.WriteAttributeString("value", string.Empty);
            writer.WriteEndElement(); //property
		}

		protected override void ExportColumnProperties(Table table, Column column)
		{
			writer.WriteStartElement("column");
            writer.WriteAttributeString("number", column.ID.ToString());
            writer.WriteAttributeString("name", column.Name);
			writer.WriteAttributeString("datatype", SmoUtil.GetDatatypeString(column));
            writer.WriteAttributeString("size", column.DataType.MaximumLength.ToString());
            writer.WriteAttributeString("nullable", column.Nullable == true ? "Y" : "N");
            writer.WriteAttributeString("inprimarykey", column.InPrimaryKey == true ? "Y" : "N");
            writer.WriteAttributeString("isforeignkey", column.IsForeignKey == true ? "Y" : "N");
			if (column.ExtendedProperties.Contains(SmoUtil.DESCRIPTION_PROPERTY))
			    writer.WriteAttributeString("description", column.ExtendedProperties[SmoUtil.DESCRIPTION_PROPERTY].Value.ToString());
			else
			    writer.WriteAttributeString("description", string.Empty);
		}
		
		protected override void ExportTableExtendedProperty(Table table, string property)
		{
            if (property != SmoUtil.DESCRIPTION_PROPERTY)
            {
                writer.WriteStartElement("property");
                writer.WriteAttributeString("name", property);
                writer.WriteAttributeString("description", string.Empty);
                writer.WriteEndElement(); //property
            }
        }
		
		protected override void ExportTableProperties(Table table)
		{
            writer.WriteStartElement("table");
            writer.WriteAttributeString("name", table.Name);
            writer.WriteAttributeString("schema", table.Schema);
            if (table.ExtendedProperties.Contains(SmoUtil.DESCRIPTION_PROPERTY))
                writer.WriteAttributeString("description", table.ExtendedProperties[SmoUtil.DESCRIPTION_PROPERTY].Value.ToString());
            else
                writer.WriteAttributeString("description", string.Empty);
        }
		
		protected override void Initialize(Stream stream)
		{
			writer = new XmlTextWriter(stream, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
		}
	}
}