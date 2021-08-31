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

        IRepository<Product> db;

        public ProductController(AppIndContext db)
        {
            this.db = new ProductRepository(db);
        }

        [HttpGet]
        public IEnumerable<Object> GetAll()
        {
            return db.GetAll();
        }

        [HttpGet("{id}")]
        public Object Get(int id)
        {
            return db.Get(id);
        }

        [HttpPost]
        public ActionResult New(Product product)
        {
            if (product == null) return BadRequest();
            db.Create(product);
            db.Save();
            return Ok(product);
        }

        [HttpPut]
        public ActionResult Update(Product product)
        {
            if (product == null) return BadRequest();
            db.Update(product);

            db.Save();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult Del(int id)
        {
            var product = db.Get(id);
            if (product == null) return NotFound();
            db.Delete(id);
            db.Save();
            return Ok(new { Message="delete success"});
        }

    }
}
