using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StormCommerce.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}