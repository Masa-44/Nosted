using System.Data;
using System.Diagnostics;
using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ijustkeeptryingiguess.Controllers
    // denne koden forklarer at den henter informasjon fra views gjennom IAction og returnerer en view/visning
{ 
    // Denne er en homecontroller Klasse som arver fra controller
    public class HomeController : Controller
    {
        // Dette deklarerer en privat readonly-variabel med navnet. Variabelen kan kun tildeles en verdi
        private readonly ServiceOrdreRepository _repository;

        // dette er konstruktøren av Homecontroller som tar imot parameter av typen serviceorderrepository
        public HomeController(ServiceOrdreRepository repository)
        {
            _repository = repository;
        }
         // henter data fra index
        public IActionResult Index()
        {
        // Viser dataen på skjermen til brukeren
            return View();
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
            // Fetch data from the repository
            var serviceOrdreList = _repository.GetAll(); 

            // Pass the data to the view
            return View(serviceOrdreList);
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

        // henter inn data fra serviceordre gjennom en repository
        public IActionResult PostService(ServiceOrdre serviceordre)
        {
            // returnerer brukeren til en annen Actionmetode
                _repository.Insert(serviceordre);
                return RedirectToAction("AktiveServiceOrdre");
           
        }


    }
}