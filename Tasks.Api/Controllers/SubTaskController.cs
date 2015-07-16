using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tasks.DataAccess.Entities;
using Tasks.Services;

namespace Tasks.Api.Controllers
{
    public class SubTaskController : ApiController
    {
        private readonly SubTaskService service = new SubTaskService();

        // GET api/subtask
        [HttpGet]
        public IEnumerable<SubTask> GetForTask(Int32 taskId)
        {
            return service.GetSubTasks(taskId);
        }

        // GET api/subtask/5
        [HttpGet]
        public SubTask Get(int id)
        {
            return service.GetSubTask(id);
        }

        // POST api/subtask
        [HttpPost]
        public void Post([FromBody]SubTask value)
        {
            service.AddSubTask(value);
        }

        // PUT api/subtask/5
        [HttpPut]
        public void Put(int id, [FromBody]SubTask value)
        {
            service.UpdateSubTask(value);
        }

        // DELETE api/subtask/5
        [HttpDelete]
        public void Delete(int id)
        {
            service.DeleteSubTask(id);
        }
    }
}
