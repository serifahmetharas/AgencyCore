using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyCore.Models
{
    public class Context : DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=agencycoredb; integrated security=true;");
        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
