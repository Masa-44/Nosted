using System.Data;
using System.Diagnostics;
using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ijustkeeptryingiguess.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceOrdreRepository _repository;

        public HomeController(ServiceOrdreRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            // Fetch data from the repository
            var serviceOrdreList = _repository.GetAll(); // Replace this with your actual method to fetch data

            // Pass the data to the view
            return View(serviceOrdreList);
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
        public IActionResult Lager()

        {
            return View();
        }

        public IActionResult Produkter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostService(ServiceOrdre serviceordre)
        {
            if (true)
            {
                _repository.Insert(serviceordre);
                return RedirectToAction("Index");
            }
            return View(serviceordre);
        }


    }
}