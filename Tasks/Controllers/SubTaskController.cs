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
    public class SubTaskController : Controller
    {
        private readonly Tasks.Api.Controllers.SubTaskController _controller = new Tasks.Api.Controllers.SubTaskController();

        public PartialViewResult _GetSubTasks(int id = 0)
        {
            ViewBag.TaskId = id;
            var subTasks = _controller.GetForTask(id);
            return PartialView(subTasks.ToList());
        }

        [ChildActionOnly]
        public PartialViewResult _SubmitForm(int id = 0)
        {
            var model = new SubTask { TaskId = id };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Submit(SubTask subtask)
        {
            if (ModelState.IsValid)
            {
                _controller.Post(subtask);
            }

            ViewBag.TaskId = subtask.TaskId;
            var subTasks = _controller.GetForTask(subtask.TaskId);
            return PartialView("_GetSubTasks", subTasks.ToList());
        }

        //
        // GET: /SubTask/Edit/5

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            SubTask subtask = _controller.Get(id);
            if (subtask == null)
            {
                return HttpNotFound();
            }
            return View(subtask);
        }

        //
        // POST: /SubTask/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubTask subtask)
        {
            if (ModelState.IsValid)
            {
                _controller.Put(0, subtask);
                return RedirectToAction("Details", "Task", new { id = subtask.TaskId });
            }
            return View(subtask);
        }

        //
        // GET: /SubTask/Delete/5

        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            SubTask subtask = _controller.Get(id);
            if (subtask == null)
            {
                return HttpNotFound();
            }
            return View(subtask);
        }

        //
        // POST: /SubTask/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTask subtask = _controller.Get(id);
            var taskId = subtask.TaskId;
            _controller.Delete(id);
            return RedirectToAction("Details", "Task", new { id = taskId });
        }

        protected override void Dispose(bool disposing)
        {
            _controller.Dispose();
            base.Dispose(disposing);
        }
    }
}