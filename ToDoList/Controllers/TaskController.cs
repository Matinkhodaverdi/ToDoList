using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.Interface;
using ToDoList.Model.Models;

namespace ToDoList.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        public IActionResult Index()
        {
            IEnumerable<Tasks> taskList = _tasksService.GetAll();
            return View(taskList);
        }

        [HttpPost]
        public IActionResult Create(string content) 
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                var newTask = new Tasks { Content = content };

                _tasksService.AddTasks(newTask);

                var obj = _tasksService.GetFirstOrDefault(x => x.Content == content);   
                return Json(new {id = obj.Id, content = obj.Content});
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult Edit(Tasks obj)
        {
            if (ModelState.IsValid)
            {
                _tasksService.UpdateTasks(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

       
        public IActionResult Delete(int id)
        {
            var obj = _tasksService.GetFirstOrDefault(x => x.Id == id);
            _tasksService.RemoveTasks(obj);
            return RedirectToAction("Index");
        }
    }
}
