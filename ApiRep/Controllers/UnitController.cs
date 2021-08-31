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
        IRepository<Unit> db;

        public UnitController(AppIndContext db)
        {
            this.db = new UnitRepository(db);
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
        public ActionResult New(Unit unit)
        {
            if (unit == null) return BadRequest();
            db.Create(unit);
            db.Save();
            return Ok(unit);
        }

        [HttpPut]
        public ActionResult Update(Unit unit)
        {
            if (unit == null) return BadRequest();
            db.Update(unit);

            db.Save();
            return Ok(unit);
        }

        [HttpDelete("{id}")]
        public ActionResult Del(int id)
        {
            var unit = db.Get(id);
            if (unit == null) return NotFound();
            db.Delete(id);
            db.Save();
            return Ok(new { Message = "delete success" });
        }
    }
}
