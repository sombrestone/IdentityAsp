using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Models
{
    public class ProductRepository: RepositoryBase<Product>
    {

        public ProductRepository(AppIndContext db) : base(db) { }

        //public ProductRepository() : base() { }

        public override IEnumerable<Object> GetAll()
        {
            return (from products in db.Products 
                    join units in db.Units on products.UnitId equals units.Id 
                    select new
                    {
                        Id= products.Id,
                        Name= products.Name,
                        Price= products.Price,
                        UnitId= units.Id,
                        UnitName=units.Name,
                        UnitShortName=units.ShortName
                    }
            ).ToList();
        }

        public override Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public override void Create(Product item)
        {
            db.Products.Add(item);
        }

        public override void Update(Product item)
        {
            db.Products.Update(item);
        }

        public override void Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
        }

        public override void Save()
        {
            db.SaveChanges();
        }
    }
}
