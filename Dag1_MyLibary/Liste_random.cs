using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Liste_random
    {
        List<int> numbers;
        public Liste_random()
        {
            this.numbers = new List<int>();

            Random rd = new Random();
            
            for (int i = 0; i < 10; i++)
            {
                int rand_num = rd.Next(0, 101);
                this.numbers.Add(rand_num);
            }
        }

        public void PrintNumbers()
        {
            Console.Write("[");
            foreach (int tal in numbers)
            {
                Console.Write(tal + ",");
            }
            Console.Write("]");
        }
    }
}
