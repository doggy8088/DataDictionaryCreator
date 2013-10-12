/*
 * Created by SharpDevelop.
 * User: tyler
 * Date: 9/28/2006
 * Time: 4:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using Microsoft.SqlServer.Management.Smo;
using DataDictionaryCreator.Properties;

namespace DataDictionaryCreator
{
	/// <summary>
	/// Description of SmoUtil.
	/// </summary>
	public class SmoUtil
	{
        public static readonly string DESCRIPTION_PROPERTY = "MS_Description";
		private SmoUtil()
		{
		}
		
        public static string GetDatatypeString(Column column)
        {
            DataType dataType = column.DataType;
            switch(dataType.SqlDataType)
            {
                case SqlDataType.Decimal:
                    return string.Format("{0} ({1},{2})", dataType.SqlDataType.ToString(), dataType.NumericPrecision, dataType.NumericScale);
                case SqlDataType.VarChar:
                case SqlDataType.NVarChar:
                case SqlDataType.Char:
                case SqlDataType.NChar:
                    return string.Format("{0} ({1})", dataType.SqlDataType.ToString(), dataType.MaximumLength);
                default:
                return column.DataType.SqlDataType.ToString();
            }
        }

        /// <summary>
        /// Because the ToolStripComboBox doesn't allow a value field and a display field
        /// we'll need to iterate through the collection to look for the table.
        /// Eventually we'll need to change the control to a regular ComboBox so we can 
        /// use the table [ID] field for the value.        
        /// </summary>        
        /// <param name="db">SMO database object.</param>
        /// <param name="tableName">Name of the table to match. e.g. [dbo].[tablename]</param>
        /// <returns></returns>
        public static Table GetTableByName(Database db, string tableName)
        {
            foreach (Table tbl in db.Tables)
            {
                if (tbl.ToString() == tableName)
                {
                    return tbl;
                }
            }

            throw new Exception(string.Format(Resources.MissingTableException, tableName));
        }
	}
}
