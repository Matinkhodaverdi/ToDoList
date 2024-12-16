using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using ToDoList.DataAccess.Interface;
using ToDoList.Model.Models;
using ToDoList.Model.ViewModel;

namespace ToDoList.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
       

        public WorkController(IWorkService workService)
        {
            _workService = workService;
        }


        public IActionResult Index()
        {
            ViewData["ActiveMenu"] = "Work";


            IEnumerable<Work> workList = _workService.GetAll();

            return View(workList);
        }


        [HttpPost]
        public IActionResult Create(WorkViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _workService.AddWork(viewModel);
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
            var WorkFromDbFirst = _workService.GetFirstOrDefault(x => x.Id == id);
            if (WorkFromDbFirst == null)
            {
                return NotFound();
            }

            return View(WorkFromDbFirst);
        }


        [HttpPost]
        public IActionResult Edit(Work obj)
        {
            if (ModelState.IsValid)
            {
                _workService.UpdateWork(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(Guid id)
        {
            var obj = _workService.GetFirstOrDefault(x => x.Id == id);
            _workService.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}
