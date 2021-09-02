using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRep.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRep.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IRepository<Product> repository;

        public ProductController(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Object> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public Object Get(int id)
        {
            return repository.Get(id);
        }

        [HttpPost]
        public ActionResult New(Product product)
        {
            if (product == null) return BadRequest();
            repository.Create(product);
            repository.Save();
            return Ok(product);
        }

        [HttpPut]
        public ActionResult Update(Product product)
        {
            if (product == null) return BadRequest();
            repository.Update(product);

            repository.Save();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Del(int id)
        {
            var product = repository.Get(id);
            if (product == null) return NotFound();
            repository.Delete(id);
            repository.Save();
            return Ok(new { Message="delete success"});
        }

    }
}
