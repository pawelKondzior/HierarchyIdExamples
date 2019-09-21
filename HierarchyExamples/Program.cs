using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMenu;
using System.IO;
using HierarchyExamples.ConsoleItems;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu;

namespace HierarchyExamples
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (DataServiceEF62 dataService = new DataServiceEF62())
            //{
            //    dataService.Add(new ProductCategoryDto()
            //    {
            //        Name = "NameTest"
            //    },null);
            //}


            new BuildMenu().Run();

            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
