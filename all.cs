using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    internal static class all
    {
       public static void PrintMenu()
        {
            Console.WriteLine("enter your choice");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Insert a person");
            Console.WriteLine("2 - Get person by name");
            Console.WriteLine("3 - Get person by secret code");
            Console.WriteLine("4 - Insert report");
            Console.WriteLine("5 - Get alerts");
            Console.WriteLine("6 - Update mention count");
        }
    }
}
