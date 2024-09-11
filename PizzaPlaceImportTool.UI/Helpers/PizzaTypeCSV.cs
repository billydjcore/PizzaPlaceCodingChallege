using PizzaPlace.Core.Entities;
using CsvHelper;
using System.Globalization;
using System.Diagnostics;
using PizzaPlaceImportTool.UI.Models;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace PizzaPlaceImportTool.UI.Helpers
{
    public class PizzaTypeCSV : CSVToSQLBulkCopy
    {
        public List<PizzaTypeRow>? PizzaTypesList { get; set; }
        public PizzaTypeCSV(string csvFileFullPath) : base(csvFileFullPath)
        {
            var result = StartImport(csvFileFullPath).Result;
            if (result)
                ImportResult = "CSV DataImport Completed Successfully!";
            else
                ImportResult = "CSV DataImport Failed!";
        }
        public override async Task<bool> StartImport(string csvFileFullPath)
        {
            bool result = false;
            DataTable? csvDt = ImportCSVToDatatable(csvFileFullPath);
            if (csvDt != null)
            {
                await CSVDataTableToSQLImport(csvDt, "Pizza_Types");
                result = true;
            }
            return result;
        }
    }
}
