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
    public class UnitController : ControllerBase
    {
        IRepository<Unit> repository;

        public UnitController(IRepository<Unit> repository)
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
        public ActionResult New(Unit unit)
        {
            if (unit == null) return BadRequest();
            repository.Create(unit);
            repository.Save();
            return Ok(unit);
        }

        [HttpPut]
        public ActionResult Update(Unit unit)
        {
            if (unit == null) return BadRequest();
            repository.Update(unit);

            repository.Save();
            return Ok(unit);
        }

        [HttpDelete("{id}")]
        public ActionResult Del(int id)
        {
            var unit = repository.Get(id);
            if (unit == null) return NotFound();
            repository.Delete(id);
            repository.Save();
            return Ok(new { Message = "delete success" });
        }
    }
}
