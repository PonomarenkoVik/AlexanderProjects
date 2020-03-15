using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject
{
    class Program
    {
        const int _size = 15;
        const string symbol = "#";

        static void Main(string[] args)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine(string.Empty);
            }
            Console.ReadLine();
        }
    }
}
