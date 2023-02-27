using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;


namespace PetHotelWPF.DAL
{
    public class PetHotelContext : DbContext
    {
        public PetHotelContext() : base("PetHotelContext")
        {
        }
        public DbSet<Pet> Pets { get; set; }
        //This says we want to have a dataset of Customers (will be a table)
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
