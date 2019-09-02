using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples63.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    class EF62Page : MenuPage
    {

        private IDataService DataService { get; set; }

        public EF62Page(Program program)
            : base("Page 1", program,
                  new Option("Display First Level", () => program.NavigateTo<DisplayFirstLevel>())
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {
            DataService = new DataServiceEF62();


            program.AddPage(new DisplayFirstLevel(DataService, program));

           

        }
    }
}
