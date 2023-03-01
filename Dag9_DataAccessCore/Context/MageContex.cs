using Dag9_DataAccessCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Dag9_DataAccessCore.Context
{
    internal class MageContex : DbContext
    {

        public MageContex()
        {
            bool created = Database.EnsureCreated();
            if (created)
            {
                Debug.WriteLine("Database created");
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-FJR3J3JQ\\SQLEXPRESS;Initial Catalog=MageDB;Integrated Security=SSPI; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mage>().HasData(new Mage[] {
                new Mage{MageId=-1,Name="Elvira", IsDark=true},
                new Mage{MageId=-2,Name="Kenny", IsDark=false},
            });
        }
        public DbSet<Mage> Mages { get; set; }
        //public DbSet<Spell> Spells { get; set; }
    }

}
