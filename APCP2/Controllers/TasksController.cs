using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APCP2.Data;
using APCP2.Services;

namespace APCP2.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _Taskservice;

        public TasksController(TaskService Taskservice) 
        {
            _Taskservice = Taskservice;
        }

        public ActionResult ProcessManager()
        {
            var Tasks = _Taskservice.GetAllTasks();
            return View(Tasks);
        }

        public ActionResult Details(int id)
        {
            var product = _Taskservice.GetTasksById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskManager tasks)
        {
            if (ModelState.IsValid)
            {
                _Taskservice.CreateTasks(tasks);
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _Taskservice.GetTasksById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskManager tasks)
        {
            if (ModelState.IsValid)
            {
                _Taskservice.UpdateTasks(tasks);
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        public ActionResult Delete(int id)
        {
            var product = _Taskservice.GetTasksById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _Taskservice.DeleteTasks(id);
            return RedirectToAction("Index");
        }
    }
}
