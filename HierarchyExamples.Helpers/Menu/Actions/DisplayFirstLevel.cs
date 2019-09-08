using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu.Actions
{

    public class DisplayFirstLevel : ActionMenuPage
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
            var topLevel = DataService.GetTopLevel();

            WriteTable("display top level", topLevel);


            Input.ReadString("Press [Enter] to navigate home");

            Program.NavigateBack();
        }

    }
}
