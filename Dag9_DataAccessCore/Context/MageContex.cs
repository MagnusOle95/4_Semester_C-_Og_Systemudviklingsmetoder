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
            modelBuilder.Entity<Spell>().HasData(new Spell[] {
                new Spell{SpellID=-1, Name="Awada Karawra", Description="The killing Curse"},
                new Spell{SpellID=-2,Name="Crusiatis", Description="Torture Curse"},
            });
            modelBuilder.Entity<Mage>().HasData(new Mage[] {
                new Mage{MageId=-1,Name="Elvira", IsDark=true},
                new Mage{MageId=-2,Name="Kenny", IsDark=false},
            });
            modelBuilder.Entity<Magespell>().HasData(new Magespell[] {
                new Magespell{MagespellId = -1, MageId = -1, SpellId = -1},
                new Magespell{MagespellId = -2, MageId = -1, SpellId = -2}

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


        }
        public DbSet<Mage> Mages { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Magespell> Magespells { get; set; }

    }

}
