using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Models
{
    public class AppIndContext : IdentityDbContext<User>
    {
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public AppIndContext() { }

        public AppIndContext(DbContextOptions<AppIndContext> options): base(options){  }
    }
}
