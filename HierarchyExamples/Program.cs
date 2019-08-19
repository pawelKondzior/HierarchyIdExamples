using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HierarchyExamples.ConsoleItems;
using ConsoleMenu;
using System.IO;

namespace HierarchyExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuHelper.GetTestMenu();


            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
