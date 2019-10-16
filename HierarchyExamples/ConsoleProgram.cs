using HierarchyExamples.Menu;
using System;

namespace HierarchyExamples
{
    internal class ConsoleProgram
    {
        private static void Main(string[] args)
        {
            new BuildMenu().Run();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}