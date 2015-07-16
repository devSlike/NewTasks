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
    public class TaskController : ApiController
    {
        private readonly TaskService service = new TaskService();

        // GET api/task
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return service.GetTasks();
        }

        // GET api/task/5
        [HttpGet]
        public Task Get(int id)
        {
            return service.GetTask(id);
        }

        // POST api/task
        [HttpPost]
        public void Post([FromBody]Task value)
        {
            service.AddTask(value);
        }

        // PUT api/task/5
        [HttpPut]
        public void Put(int id, [FromBody]Task value)
        {
            service.UpdateTask(value);
        }

        // DELETE api/task/5
        [HttpDelete]
        public void Delete(int id)
        {
            service.DeleteTask(id);
        }

        [HttpDelete]
        public void DeleteCompleted()
        {
            service.DeleteCompletedTasks();
        }
    }
}
