using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HierarchyExamples.Helpers.Menu.Actions
{
    public abstract class ActionMenuPage : MenuPage
    {
        public static int CurrentParentID { get; set; }

        public static string CurrentLevelIdP { get; set; }
        protected IDataService DataService { get; set; }

        public ActionMenuPage(IDataService dataService, string title, Program program, params Option[] options)
            : base(title, program, options)
        {
            DataService = dataService;
        }


        public void WriteTable(string name, List<ProductCategoryDto> list)
        {
            if (list.Any())
            {

                Output.WriteLine(string.Format("Table: {0}", name));

                var listBuilder = ConsoleTableBuilder.From(list);

                listBuilder
                     .WithFormat(ConsoleTableBuilderFormat.Alternative)
                     .ExportAndWriteLine();
            }
            else
            {
                Output.WriteLine("No items in list");
            }
           
        }


        //public override void Display()
        //{
        //    base.Display();
        //}
    }
}
