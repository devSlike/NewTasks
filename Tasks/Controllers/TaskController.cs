using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tasks.DataAccess.Entities;

namespace Tasks.Controllers
{
    public class TaskController : Controller
    {
        private Tasks.Api.Controllers.TaskController _controller = new Tasks.Api.Controllers.TaskController();

        //
        // GET: /Task/
        [HttpGet]
        public ActionResult Index()
        {
            var tasks = GetTasks();
            return View(tasks);
        }

        private List<Task> GetTasks()
        {
            try
            {
                var s = _controller.Get();
                var tasks = JsonConvert.DeserializeObject<List<Task>>(s);
                return tasks;
            }
            catch
            {
                return new List<Task>();
            }
        }

        //
        // GET: /Task/Details/5
        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            Task task = GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //
        // GET: /Task/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CategoryId = CategoryList();
            return View();
        }

        private SelectList CategoryList()
        {
            using (var cat = new Tasks.Api.Controllers.CategoryController())
            {
                var s = cat.Get();
                var items = JsonConvert.DeserializeObject<List<Category>>(s);
                return new SelectList(items, "Id", "CategoryName");
            }
        }

        //
        // POST: /Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                _controller.Post(task);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = CategoryList();
            return View(task);
        }

        //
        // GET: /Task/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Task task = GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = CategoryList();
            return View(task);
        }

        private Task GetTaskById(int id)
        {
            try
            {
                var s = _controller.Get(id);
                Task task = JsonConvert.DeserializeObject<Task>(s);
                return task;
            }
            catch
            {
                return null;
            }
        }

        //
        // POST: /Task/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                _controller.Put(0, task);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = CategoryList();
            return View(task);
        }

        //
        // GET: /Task/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Task task = GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        //
        // POST: /Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _controller.Delete(id);
            return RedirectToAction("Index");
        }

        //
        // GET: /Task/DeleteCompleted/
        [HttpGet]
        public ActionResult DeleteCompleted()
        {
            return View();
        }

        //
        // POST: /Task/DeleteCompleted/
        [HttpPost, ActionName("DeleteCompleted")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCompletedConfirmed()
        {
            _controller.DeleteCompleted();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _controller.Dispose();
            base.Dispose(disposing);
        }
    }
}