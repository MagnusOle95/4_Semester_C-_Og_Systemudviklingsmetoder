using PersonServerAPI.Model;

namespace PersonServerAPI
{
    public class Personer
    {
        private static List<Person> Persons = new List<Person>();
        public static void LavTestPersoner()
        {
            Persons.Add(new Person("Frank",22));
            Persons.Add(new Person("Benny",55));
        }
        public static List<Person> GetAllePersons()
        {
            return Persons;
        }
        public static Person GetPersonById(int id)
        {
            Person p = null;
            Boolean found = false;
            int i = 0;
            while (i < Persons.Count && !found) 
            {
                Person k = Persons[i];
                if (k.Id == id)
                {
                    found = true;
                    p = k;
                }
                i++;
            }
            return p;
        }

        internal static void createPerson(string name, int age)
        {
            Person p = new Person(name,age);
            AddPerson(p);
        }

        internal static void AddPerson(Person Person)
        {
            Persons.Add(Person);
        }
    }
}
