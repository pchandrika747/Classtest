using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace WebApi_withLTI.Modules
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>option) : base(option)
        {

        }
        // ORM Object Relational MApping of table with Model
        public DbSet<Product> Product { get; set; }
        // Dbset is matched table name
        public DbSet<Category> Category { get; set; }

    }

}
