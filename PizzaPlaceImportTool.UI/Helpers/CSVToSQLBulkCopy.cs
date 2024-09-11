using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PizzaPlaceImportTool.UI.Helpers
{
    public abstract class CSVToSQLBulkCopy
    {
        public string ImportResult { get; set; }
        string _fileFullPath = string.Empty;
        public CSVToSQLBulkCopy(string fileFullPath)
        {
            _fileFullPath = fileFullPath;
        }

        public virtual async Task<bool> StartImport(string csvFileFullPath)
        {
            bool result = false;
            DataTable? csvDt = ImportCSVToDatatable(csvFileFullPath);
            if (csvDt != null)
            {
                await CSVDataTableToSQLImport(csvDt, "Pizzas");
                result = true;
            }
            return result;
        }
        public DataTable? ImportCSVToDatatable(string csvfilePath)
        {
            DataTable csvDt = new DataTable();
            try
            {
                using (TextFieldParser csvRowParser = new TextFieldParser(csvfilePath))
                {
                    csvRowParser.SetDelimiters(",");
                    csvRowParser.HasFieldsEnclosedInQuotes = true;
                    string[]? columnsFields = csvRowParser.ReadFields();
                    if (columnsFields == null)
                        return null;
                    foreach (string columns in columnsFields)
                    {
                        DataColumn csvColumn = new DataColumn(columns);
                        csvDt.Columns.Add(csvColumn);
                    }

                    while (!csvRowParser.EndOfData)
                    {
                        string[]? rowField = csvRowParser.ReadFields();
                        if (rowField == null)
                            return null;
                        for (int i = 0; i < rowField.Length; i++)
                        {
                            if (string.IsNullOrEmpty(rowField[i]))
                                rowField[i] = null;
                        }
                        csvDt.Rows.Add(rowField);
                    }
                    Console.WriteLine(csvDt.Rows.Count);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return csvDt;
        }

        public async Task<bool> CSVDataTableToSQLImport(DataTable csvData,string tblName) 
        {
            bool isCompleted = false;
            try
            { 
                using(SqlConnection sQLConnection = new SqlConnection(@"Data Source=BARYAMANIN\SQLEXPRESS; Initial Catalog=PizzaPlaceDB; Integrated Security=SSPI;")) 
                {
                    sQLConnection.Open();
                    using (SqlBulkCopy sqlCopy = new SqlBulkCopy(sQLConnection))
                    {
                        sqlCopy.DestinationTableName = tblName;
                        foreach(var column in csvData.Columns) 
                        {
                            sqlCopy.ColumnMappings.Add(column.ToString(),column.ToString());
                        }
                        await sqlCopy.WriteToServerAsync(csvData);
                    }
                }
                isCompleted = true;
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex.Message);
            }

            return isCompleted;
        }
    }
}
