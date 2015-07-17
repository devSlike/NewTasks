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
    public class CategoryController : Controller
    {
        private readonly Tasks.Api.Controllers.CategoryController _controller = new Api.Controllers.CategoryController();

        //
        // GET: /Category/
        [HttpGet]
        public ActionResult Index()
        {
            var s = _controller.Get();
            var items = JsonConvert.DeserializeObject<List<Category>>(s);
            return View(items);
        }

        //
        // GET: /Category/Details/5
        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            var s = _controller.Get(id);
            Category category = JsonConvert.DeserializeObject<Category>(s);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _controller.Post(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }
        
        // GET: /Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var s = _controller.Get(id);
            Category category = JsonConvert.DeserializeObject<Category>(s);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _controller.Put(0, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //
        // GET: /Category/Delete/5
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            var s = _controller.Get(id);
            Category category = JsonConvert.DeserializeObject<Category>(s);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _controller.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _controller.Dispose();
            base.Dispose(disposing);
        }
    }
}