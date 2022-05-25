using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templet.DAL.Entities;

namespace Templet.DAL.Database
{
   public class DbContainer : DbContext
    {
        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts)
        {
                
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server= DESKTOP-PQNJJN3\\SQLEXPRESS ; database=HendSharpDb; integrated security=true");
        //}
    }
}
