using Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BilContext : DbContext
    {
        public BilContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=EAA-SH-KLBO-KU\\SQLEXPRESS;Initial Catalog=Biler1;Integrated Security=SSPI; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bil>().HasData(new Bil[] {
                new Bil{BilID=-1,Name="Ford", Weight= 1400 }//, Firma=null }
            });
        }

        public DbSet<Bil> Biler { get; set; }
        //public DbSet<Firma> Firmaer { get; set; }
        //public DbSet<Ejer> Ejer { get; set; }
    }
}
