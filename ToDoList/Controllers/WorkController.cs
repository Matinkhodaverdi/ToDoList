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
        private PersianCalendar pc = new PersianCalendar();

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
        public IActionResult Create(Work obj)
        {
            if (ModelState.IsValid)
            {
                _workService.AddWork(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
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
