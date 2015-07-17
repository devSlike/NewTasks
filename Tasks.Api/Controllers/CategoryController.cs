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
    public class CategoryController : ApiController
    {
        private readonly CategoryService service;
        private readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public CategoryController()
        {
            IoC.Init();
            var uowf = IoC.Get<IUnitOfWorkFactory>();
            service = new CategoryService(uowf);
        }

        // GET api/category
        [HttpGet]
        public String Get()
        {
            var cats = service.GetCategories();
            var json = JsonConvert.SerializeObject(cats, jsonSettings);
            return json;
        }

        // GET api/category/5
        [HttpGet]
        public String Get(int id)
        {
            var cat = service.GetCategory(id);
            var json = JsonConvert.SerializeObject(cat, jsonSettings);
            return json;
        }

        // POST api/category
        [HttpPost]
        public void Post([FromBody]Category value)
        {
            service.AddCategory(value);
        }

        // PUT api/category/5
        [HttpPut]
        public void Put(int id, [FromBody]Category value)
        {
            service.UpdateCategory(value);
        }

        // DELETE api/category/5
        [HttpDelete]
        public void Delete(int id)
        {
            service.DeleteCategory(id);
        }
    }
}
