using System.Diagnostics;
using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ijustkeeptryingiguess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Sjekkliste()
        {
            var model = new CheckListViewModel();
            return View(model);
        }
        public IActionResult NyServiceOrdre()
        {
            return View();
        }
        public IActionResult AktiveServiceOrdre()
        {
            return View();
        }
        public IActionResult Vaktliste()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lager()
           
        {
            return View();
        }

        public IActionResult Produkter()
        {
            return View();
;        }

        
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