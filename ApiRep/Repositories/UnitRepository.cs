using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Models
{
    public class UnitRepository: RepositoryBase<Unit>
    {
        public UnitRepository(AppIndContext db) : base(db) { }

        public override IEnumerable<Object> GetAll()
        {
            return (from units in db.Units select units).ToList();
        }

        public override Unit Get(int id)
        {
            return db.Units.Find(id);
        }

        public override void Create(Unit item)
        {
            db.Units.Add(item);
        }

        public override void Update(Unit item)
        {
            db.Units.Update(item);
        }

        public override void Delete(int id)
        {
            db.Units.Remove(db.Units.Find(id));
        }

        public override void Save()
        {
            db.SaveChanges();
        }
    }
}
