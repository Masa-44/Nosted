using Ijustkeeptryingiguess.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ijustkeeptryingiguess.Controllers
{
    public class ServiceOrderController : Controller
    {
        private readonly ServiceOrdreRepository _repository;

        public ServiceOrderController(ServiceOrdreRepository repository)
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NyServiceOrdre(ServiceOrdre serviceordre)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(serviceordre);
                return RedirectToAction("Index");
            }
            return View(serviceordre);
        }
    }
}
