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
    public class CategoryController : ApiController
    {
        private readonly CategoryService service = new CategoryService();

        // GET api/category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return service.GetCategories();
        }

        // GET api/category/5
        [HttpGet]
        public Category Get(int id)
        {
            return service.GetCategory(id);
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
