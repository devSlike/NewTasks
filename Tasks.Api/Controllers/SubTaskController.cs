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
    public class SubTaskController : ApiController
    {
        private readonly SubTaskService service;
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public SubTaskController()
        {
            IoC.Init();
            var uowf = IoC.Get<IUnitOfWorkFactory>();
            service = new SubTaskService(uowf);
        }
        
        // GET api/subtask
        [HttpGet]
        public String GetForTask(Int32 taskId)
        {
            var tasks = service.GetSubTasks(taskId);
            var json = JsonConvert.SerializeObject(tasks, jsonSettings);
            return json;
        }

        // GET api/subtask/5
        [HttpGet]
        public String Get(int id)
        {
            var task = service.GetSubTask(id);
            var json = JsonConvert.SerializeObject(task, jsonSettings);
            return json;
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
