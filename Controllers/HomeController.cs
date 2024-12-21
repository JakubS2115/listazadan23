using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Models;
using System.Collections.Generic;

namespace TaskManagerApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<TaskManagerApp.Models.Task> tasks = new List<TaskManagerApp.Models.Task>
        {
            new TaskManagerApp.Models.Task { Id = 1, Title = "Nauczyæ sie matematyki", IsCompleted = false },
            new TaskManagerApp.Models.Task { Id = 2, Title = "Odrobiæ zadania", IsCompleted = true }
        };

        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskManagerApp.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                task.Id = tasks.Count > 0 ? tasks[^1].Id + 1 : 1;
                tasks.Add(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            return RedirectToAction("Index");
        }
    }
}
