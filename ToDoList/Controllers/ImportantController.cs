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
            ViewData["ActiveMenu"] = "Important";


            IEnumerable<Important> ImportantList = _importantService.GetAll();

            return View(ImportantList);
        }


        [HttpPost]
        public IActionResult Create(ImportantViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _importantService.AddImportant(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var ImportantFromDbFirst = _importantService.GetFirstOrDefault(x => x.Id == id);
            if (ImportantFromDbFirst == null)
            {
                return NotFound();
            }

            return View(ImportantFromDbFirst);
        }


        [HttpPost]
        public IActionResult Edit(Important obj)
        {
            if (ModelState.IsValid)
            {
                _importantService.UpdateImportant(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(Guid id)
        {
            var obj = _importantService.GetFirstOrDefault(x => x.Id == id);
            _importantService.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}