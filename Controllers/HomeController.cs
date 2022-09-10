using FirstMVCCoreApp.Models;
using FirstMVCCoreApp.Repsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FirstMVCCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
           
        }

        public IActionResult Index()
        {
            return View();
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

        public JsonResult GetjsonData()
        {
            EmployeeModel _employee = new EmployeeModel();
            _employee.EmpId = 1;
            _employee.EmpName = "Saquib";
            _employee.EmpSalary = 2000;

            return Json(_employee);
        }

        public ContentResult GetContent()
        {
            return Content("hi this is Hello World");
        }

        public RedirectResult GetFile()
        {
            
            return Redirect("");
        }

        public ActionResult GetEmployeeData()
        {

            _logger.LogTrace("Trace log");
            _logger.LogDebug("debug log");
            _logger.LogInformation("Information log");
            _logger.LogWarning("warning log");
            _logger.LogError("Error log");
            _logger.LogCritical("Critical log");
            return View(_employeeRepository.GetEmployees());
        }

    }
}
