using CsvHelper;
using PizzaPlace.Core.Entities;
using PizzaPlaceImportTool.UI.Models;
using System.Data;
using System.Diagnostics;
using System.Globalization;

namespace PizzaPlaceImportTool.UI.Helpers
{
    public class OrdersCSV : CSVToSQLBulkCopy
    {
        public OrdersCSV(string csvFileFullPath) : base(csvFileFullPath)
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
                await CSVDataTableToSQLImport(csvDt, "Orders");
                result = true;
            }
            return result;
        }

        //public List<OrderRow>? OrderList { get; set; }
        //public void ImportCSV(string csvfilePath)
        //{
        //    OrderList = new List<OrderRow>();
        //    using (var reader = new StreamReader(csvfilePath))
        //    {
        //        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //        {
        //            csv.Read();
        //            csv.ReadHeader();
        //            while (csv.Read())
        //            {
        //                var order = csv.GetRecord<OrderRow>();
        //                OrderList.Add(order);
        //            }
        //        }
        //    }
        //    Debug.WriteLine(OrderList.Count);
        //}

    }
}
