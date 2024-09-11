using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaPlaceImportTool.UI.Helpers;
using PizzaPlaceImportTool.UI.Models;
using System.Diagnostics;
using System.Linq.Expressions;

namespace PizzaPlaceImportTool.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _hostingEnvironment;
        string csvFilesFullPath = string.Empty;
        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;         
        }

        public IActionResult Index()
        {
            CSVFileImportSetup csvFileImportSetup = new CSVFileImportSetup();
            csvFileImportSetup.SelectedCSVFile = "";
            csvFileImportSetup.ImportResult = "Waiting...";
            ViewData["CSVFileList"] = _hostingEnvironment.WebRootFileProvider.GetDirectoryContents("csvfiles").ToList().Select(f => Path.GetFileName(f.PhysicalPath)).ToList();
           
            return View(csvFileImportSetup);
        }
        [HttpPost]
        public IActionResult Index(CSVFileImportSetup csvFileImport)
        {
            csvFileImport.CSVFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "csvfiles");

            CSVFileImportWorker csvImportWorker = new CSVFileImportWorker(csvFileImport.SelectedCSVFile, csvFileImport.CSVFilePath);
            string importResult = string.Empty;
            csvImportWorker.StartCSVImport(out importResult);
            csvFileImport.ImportResult = importResult;
            ViewData["CSVFileList"] = _hostingEnvironment.WebRootFileProvider.GetDirectoryContents("csvfiles").ToList().Select(f => Path.GetFileName(f.PhysicalPath)).ToList();
            return View(csvFileImport);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
