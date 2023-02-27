using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace PetHotelWPF
{
    public class Employee
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public virtual ObservableCollection<Pet> TakesCareOfPets { get; set; }


        public override string ToString()
        {
            return Name;
        }
        public Employee()
        {

        }

        public Employee(string name)
        {
            this.Name = name;
        }

        public void AddPet(Pet pet)
        {
            TakesCareOfPets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            TakesCareOfPets.Remove(pet);
        }


    }
}
