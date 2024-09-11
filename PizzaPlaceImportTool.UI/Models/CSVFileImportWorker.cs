using PizzaPlaceImportTool.UI.Helpers;
namespace PizzaPlaceImportTool.UI.Models
{ 
    public class CSVFileImportWorker
    {
        private CSVToSQLBulkCopy _cSVDataImportService;
      
        private string _filePath;
        private string _fileName;
        public CSVFileImportWorker(string fileName,string filePath)
        {
            _filePath = filePath;
            _fileName = fileName;
        }
       
        /// <summary>
        /// StartCSVImport .
        /// </summary>
        public void StartCSVImport(out string result)
        {
            result = "";
            string fileFullPath = $"{_filePath}\\{_fileName}";
            switch (_fileName)
            {
                case "orders.csv":
                    {
                        _cSVDataImportService = new OrdersCSV(fileFullPath);
                        break;
                    }
                case "order_details.csv":
                    {
                        _cSVDataImportService = new OrderDetailsCSV(fileFullPath);
                        break;
                    }
                case "pizzas.csv":
                    {
                        _cSVDataImportService = new PizzaCSV(fileFullPath);
                        break;
                    }
                default:
                    {
                        _cSVDataImportService = new PizzaTypeCSV(fileFullPath);
                        break;
                    }
            }
            result = _cSVDataImportService.ImportResult;


        }

       
    }
  
}
