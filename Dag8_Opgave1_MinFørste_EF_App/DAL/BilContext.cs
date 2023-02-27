using Dag8_Opgave1_MinFørste_EF_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag8_Opgave1_MinFørste_EF_App.DAL
{
    public class BilContext : DbContext
    {
        public BilContext()
        {
        }
        public DbSet<Bil> Biler { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-FJR3J3JQ\\SQLEXPRESS;Initial Catalog=Biler1;Integrated Security=SSPI; TrustServerCertificate=true");
        }
    }
}
