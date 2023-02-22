using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Dag7_Opgave5_NewWindow_MenuWindow
{
    public class Person : INotifyPropertyChanged
    {
        public string name;
        public int age;
        public int weight;
        public int score;
        public Boolean accepted;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Person() { }
        public Person(string name, int age, int weight, int score, Boolean accepted) 
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.score = score;
            this.accepted = accepted;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                NotifyPropertyChanged("Weight");
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }
        }

        public Boolean Accepted
        {
            get
            {
                return accepted;
            }
            set
            {
                accepted = value;
                NotifyPropertyChanged("Accepted");
            }
        }

        public string ToString()
        {
            return name + " " + age + " " + weight + " " + score + " " + accepted;
        }








    }
}
