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
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VMKKTQO;Initial Catalog=MageDB;Integrated Security=SSPI; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spell>().HasData(new Spell[] {
                new Spell{SpellID=-1, Name="Awada Karawra", Description="The killing Curse"},
                new Spell{SpellID=-2,Name="Crusiatis", Description="Torture Curse"},
            });
            modelBuilder.Entity<Mage>().HasData(new Mage[] {
                new Mage{MageId=-1,Name="Elvira", IsDark=true},
                new Mage{MageId=-2,Name="Kenny", IsDark=false},
            });
            modelBuilder.Entity<Magespell>().HasData(new Magespell[] {
                new Magespell{MageId = -1, SpellId = -1},
                new Magespell{MageId = -1, SpellId = -2}

            });

            modelBuilder.Entity<Magespell>()
            .HasKey(ms => new { ms.MageId, ms.SpellId });

            modelBuilder.Entity<Magespell>()
                .HasOne(ms => ms.Mage)
                .WithMany(m => m.MageSpells)
                .HasForeignKey(ms => ms.MageId);

            modelBuilder.Entity<Magespell>()
                .HasOne(ms => ms.Spell)
                .WithMany(s => s.MageSpells)
                .HasForeignKey(ms => ms.SpellId);


            modelBuilder.Entity<School>().HasData(new School[] {
                new School{SchoolId = -1, SchoolName = "Hogwarts", City = "Edinburgh", CountryCode = "GB-SCT"},
                new School{SchoolId = -2, SchoolName = "Beauxbatons", City = "Paris", CountryCode = "FR"},
                new School{SchoolId = -3, SchoolName = "Durmstrang", City = "Oslo", CountryCode = "NO"},
                new School{SchoolId = -4, SchoolName = "Mahoutokoro", City = "Tokyo", CountryCode = "JP"},
                new School{SchoolId = -5, SchoolName = "Uagadou", City = "Kampala", CountryCode = "UG"},
                new School{SchoolId = -6, SchoolName = "Castelobruxo", City = "Brasília", CountryCode = "BR"},
                new School{SchoolId = -7, SchoolName = "Ilvermorny", City = "Washington D.C.", CountryCode = "US"}
                });

        }
        public DbSet<Mage> Mages { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Magespell> Magespells { get; set; }
        public DbSet<School> Schools { get; set; }

    }

}
