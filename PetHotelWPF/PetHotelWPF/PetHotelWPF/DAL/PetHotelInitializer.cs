using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHotelWPF.DAL;
using System.Data.Entity;

namespace PetHotelWPF.DAL
{
    public class PetHotelInitializer :  CreateDatabaseIfNotExists<PetHotelContext>
    //other options are
    //DropCreateDataBaseAlways
    //DropCreateDataBaseIfModelChange
    {
        protected override void Seed(PetHotelContext context)
        {
            List<Customer> customers = new List<Customer>();
            Customer c1 = new Customer("martin", "aarhus");
            Customer c2 = new Customer("benny", "Esbjerg");
            customers.Add(c1);
            customers.Add(c2);

            //here we add all of our customers to the dataset in the context
            customers.ForEach(customer => context.Customers.Add(customer));

            Pet p1 = new Pet(1, "doggy", "Dog"); //belongs to customer 1
            Pet p2 = new Pet(1, "snaky", "Snake"); //belongs to customer 1
            Pet p3 = new Pet(2, "catty", "Cat"); //belongs to customer 2

            p1.Age = 3;
            p2.Age = 4;
            p3.Age = 10;
            p3.IsGuestNow = true;
            //another way to add the pets - this time manually instead of from a list
            context.Pets.Add(p1);
            context.Pets.Add(p2);
            context.Pets.Add(p3);

            //saving changes
            context.SaveChanges();


        }
    } //end of class
   
}
