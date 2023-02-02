using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Liste
    {
        List<int> numbers;
        public Liste() {
            this.numbers = new List<int>();
        }

        public void addNumber(int tal)
        {
            numbers.Add(tal);
        }

        public void PrintNumbers()
        {
            Console.Write("[");
            foreach (int tal in numbers) {
            Console.Write(tal+",");
            }
            Console.Write("]");
        }





    }
}
