using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many recoreds you wants?");
            int numrecord = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < numrecord; i++)
            {
                try
                {
                    string Name = "";
                    int Age = 0;
                    Console.WriteLine("Enter Name: ");
                    Name = Console.ReadLine();
                    if (Name.Length == 0)
                    {
                        Console.WriteLine("Name is required");
                        Console.ReadLine();
                        return;
                    }
                    Console.WriteLine("Enter Age: ");
                    Age = Convert.ToInt16(Console.ReadLine());
                    if (Age > 100)
                    {
                        Console.WriteLine("Age is not valid");
                        Console.ReadLine();
                        return;
                    }
                    Console.WriteLine("Hello " + Name + " " + Age);
                    Console.ReadLine();
                }
                catch(Exception e)
                {
                    Console.WriteLine("Please enter ...Invalid data");
                }
            }
        }
    }
}
