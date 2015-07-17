using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tasks.DataAccess.Entities;
using Tasks.DataAccess.Infrastructure;
using Tasks.Services;

namespace Tasks.Api.Controllers
{
    public class TaskController : ApiController
    {
        private readonly TaskService service;
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public TaskController()
        {
            IoC.Init();
            var uowf = IoC.Get<IUnitOfWorkFactory>();
            service = new TaskService(uowf);
        }

        // GET api/task
        [HttpGet]
        public String Get()
        {
            var tasks = service.GetTasks();
            var json = JsonConvert.SerializeObject(tasks, jsonSettings);
            return json;
        }

        // GET api/task/5
        [HttpGet]
        public String Get(int id)
        {
            var task = service.GetTask(id);
            var json = JsonConvert.SerializeObject(task, jsonSettings);
            return json;
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
