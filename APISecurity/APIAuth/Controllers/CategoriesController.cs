using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIAuth.Models;

namespace APIAuth.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoryRepository categoryRepository = new CategoryRepository();
        public ICollection<Category> Get()
        {
            return categoryRepository.GetCategories();
        }

        public Category Get(int id)
        {
            return categoryRepository.GetCategory(id);
        }

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            int result = categoryRepository.Insert(category);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Category category)
        {
            int result = categoryRepository.Update(category);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            int result = categoryRepository.Delete(id);
            return Ok();
        }

    }
}
