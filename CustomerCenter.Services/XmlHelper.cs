using System;
using System.Data;
using System.IO;
using System.Xml;

namespace CustomerCenter.Services
{
    /// <summary>
    /// Helper to manipulate xml objects
    /// </summary>
    public static class XmlHelper
    {
        public static DataTable XmlToDataTable(string xml)
        {
            DataSet dsResult = new DataSet();

            if (string.IsNullOrEmpty(xml))
                return new DataTable();

            dsResult.ReadXml(new StringReader(xml));

            return dsResult.Tables[0];
        }


        /// <summary>
        /// Get a node value from xmlData based on xPathExpression
        /// </summary>
        /// <param name="xmlData"></param>
        /// <param name="xPathExpression"></param>
        /// <example>XmlHelper.GetXmlNodeValue(xmlQuote, "WorkFormData/txtNotes")</example>
        /// <returns>string</returns>
        public static string GetXmlNodeValue(string xmlData, string xPathExpression)
        {

            if (string.IsNullOrWhiteSpace(xmlData))
                return "";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlData);

            XmlNode xNode = doc.SelectSingleNode(xPathExpression);
            if (xNode == null)
                return "";

            return xNode.InnerText;
        }

    }
}
