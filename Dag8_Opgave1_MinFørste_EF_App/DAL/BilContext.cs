using Dag8_Opgave1_MinFørste_EF_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag8_Opgave1_MinFørste_EF_App.DAL
{
    public class BilContext: DbContext
    {
        public BilContext()
        {
        }
        public DbSet<Bil> Biler { get; set; }
        //public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-FJR3J3JQ\\SQLEXPRESS;Initial Catalog=Biler1;Integrated Security=SSPI; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Person p1 = new Person { PERSONID = -1, Name = "Lars", Age = 22};
            Person p2 = new Person { PERSONID = 1, Name = "Jenner", Age = 40 };
            modelBuilder.Entity<Person>().HasData(new Person[] { p1, p2});

            Bil b1 = new Bil { BILID = -1, Name = "Ford", Weigth = 1400, Diesel = true };
            Bil b2 = new Bil { BILID = 1, Name = "Kia", Weigth = 1900, Diesel = false };
            Bil b3 = new Bil { BILID = 2, Name = "VolksWagen", Weigth = 1300, Diesel = false };
            modelBuilder.Entity<Bil>().HasData(new Bil[] { b1, b2, b3 });
        }



    }
}
