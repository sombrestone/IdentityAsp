using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
