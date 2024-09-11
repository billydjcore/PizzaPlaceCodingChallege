using CsvHelper;
using PizzaPlace.Core.Entities;
using PizzaPlaceImportTool.UI.Models;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace PizzaPlaceImportTool.UI.Helpers
{
    public class PizzaCSV :  CSVToSQLBulkCopy
    {
        public List<PizzaRow> PizzaList { get; set; }

        public PizzaCSV(string csvFileFullPath) : base(csvFileFullPath) 
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
                await CSVDataTableToSQLImport(csvDt, "Pizzas");
                result = true;
            }
            return result;
        }
    }
}
