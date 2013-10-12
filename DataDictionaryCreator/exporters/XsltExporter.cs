using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Windows.Forms;

namespace DataDictionaryCreator
{
	/// <summary>
	/// Description of XsltExporter.
	/// </summary>
	public class XsltExporter : XmlExporter
	{
		FileInfo transformFileInfo;
		public XsltExporter(string transformFileName) : base()
		{
			transformFileInfo = new FileInfo(Application.StartupPath + "/xsl/" + transformFileName);
			if (!transformFileInfo.Exists)
				throw new FileNotFoundException("Unable to find file converter: " + transformFileInfo.FullName);
		}
		
		protected override void SaveTo(MemoryStream stream, string fileName)
		{
            XslCompiledTransform xslTran = new XslCompiledTransform();
            xslTran.Load(transformFileInfo.FullName);
            XmlWriter writer = XmlWriter.Create(fileName, xslTran.OutputSettings);
            xslTran.Transform(new XPathDocument(stream), null, writer);
            writer.Close();
		}
	}
}
