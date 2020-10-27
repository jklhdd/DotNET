using Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.Write("Input number: ");
            input = Console.ReadLine();
            try
            {
                ConvertType c = new ConvertType();
                int n = c.StringToInt(input);
                Console.WriteLine(n.GetType());
                Console.WriteLine("n = " + n);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
