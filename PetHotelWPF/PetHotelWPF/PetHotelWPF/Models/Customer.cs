using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Collections.ObjectModel;


namespace PetHotelWPF
{
    public class Customer
    {
        public int ID { get; set; }

        public String Name { get; set; }
        public String Address { get; set; }
        //we have a collection of pets, one customer can own more than one pet.
        public virtual ObservableCollection<Pet> Pets { get; set; }

        public Customer()
        {
            // Pets = new ObservableCollection<Pet>();
        } //empty constructor


        //constructor
        public Customer(String name, String address)
        {
            this.Name = name;
            this.Address = address;
        }

    }
}
