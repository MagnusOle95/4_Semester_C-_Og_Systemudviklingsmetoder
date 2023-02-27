namespace PetHotelWPF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetHotelWPF.DAL.PetHotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PetHotelWPF.DAL.PetHotelContext";
        }

        protected override void Seed(PetHotelWPF.DAL.PetHotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Employee benn = new Employee("Benn");
            context.Employees.AddOrUpdate(benn);
            context.SaveChanges();
        }
    }
}
