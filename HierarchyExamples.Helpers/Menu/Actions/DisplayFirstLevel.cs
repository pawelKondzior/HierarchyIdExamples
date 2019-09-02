using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu.Actions
{

    public class ActionMenuPage : MenuPage
    {
        protected IDataService DataService { get; set; }

        public ActionMenuPage(IDataService dataService, string title, Program program, params Option[] options)
            : base(title, program, options)
        {
            DataService = dataService;
        }


        public void WriteTable(string name, List<ProductCategoryDto> list)
        {
            Output.WriteLine(string.Format("Table: {0}", name));


            foreach (var )

                Output.WriteLine()
        }

    }



    class DisplayFirstLevel : ActionMenuPage
    {
        public DisplayFirstLevel(IDataService dataService, Program program)
            : base(dataService, "DisplayFirstLevel", program
                  //new Option("Page 1A", () => program.NavigateTo<Page1A>()),
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {
           
        }

        public override void Display()
        {
            base.Display();

            var topLevel = DataService.GetTopLevel();

           

           

            

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }

    }
}
