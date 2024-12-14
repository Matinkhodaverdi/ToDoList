using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ToDoList.DataAccess.Interface;
using ToDoList.Model.Models;
using ToDoList.Model.ViewModel;

namespace ToDoList.Controllers
{
    public class ImportantController : Controller
    {
        private readonly IImportantService _importantService;
        
        public ImportantController(IImportantService importantService)
        {
            _importantService = importantService;
        }


        public IActionResult Index()
        {
            IEnumerable<Important> importantList = _importantService.GetAll();
            return View(importantList);
        }


        [HttpPost]
        public IActionResult Create(Important obj)
        {
            if(ModelState.IsValid)
            {
                _importantService.AddImportant(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
