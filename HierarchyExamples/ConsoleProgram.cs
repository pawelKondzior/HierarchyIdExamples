using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;
using System.IO;
using HierarchyExamples.Contracts;
using HierarchyExamples.Menu;

namespace HierarchyExamples
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {
            new BuildMenu().Run();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
