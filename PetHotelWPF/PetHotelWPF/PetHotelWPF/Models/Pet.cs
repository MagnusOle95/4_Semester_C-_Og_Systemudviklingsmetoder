using System;
using System.Collections.Generic;
using System.Text;

namespace PetHotelWPF
{
    public class Pet
    {
        //This will be the ID of the pet
        public int PetID { get; set; }
        //This will be the foreign key of the customer, linking the two
        //tables in the database
        public int CustomerID { get; set; }
        //This will be the actual customer reference
        //we use virtual so we can use "lazy" loading
        public int EmployeID { get; set; }
        public virtual Employee Employee {get; set;}
        public virtual Customer Customer { get; set; }

        public String PetName { get; set; }
        public String Specie { get; set; }
        public int Age   { get; set; }

        public bool IsGuestNow { get; set; }

        public override string ToString()
        {
            return $"ID: {PetID} , {PetName} of specie {Specie}, age : {Age}";
        }

        //We need an empty constructor to get things to work.
        public Pet()
        {
        }

        public Pet(int customerId, String petname, String specie)
        {
            this.CustomerID = customerId;
            this.PetName = petname;
            this.Specie = specie;
            //default values here
            this.Age = 0;
            this.IsGuestNow = false;
        }


    }
}
