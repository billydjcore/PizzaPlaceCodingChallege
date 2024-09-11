namespace PizzaPlaceImportTool.UI.Models
{
    public class CSVFileImportSetup
    {
        public string? CSVFilePath { get; set;}

        public List<string>? CSVFileList { get; set; }

        public string? SelectedCSVFile { get; set; }

        public string? ImportResult { get; set; }

        public Dictionary<string, string>? CSVFileDBMap { get; set; }

    }
}
