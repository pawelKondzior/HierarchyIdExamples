using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers;
using HierarchyExamples.Menu.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Menu.Actions
{

    public class DisplayFirstLevel : ActionMenuPage
    {
        public DisplayFirstLevel(IDataService dataService, Program program)
            : base(dataService, "Display First Level", program)
        {
        }

        public override void Display()
        {
            var topLevel = DataService.GetTopLevel();

            DisplayHelpers.WriteTable("display top level", topLevel);

            Input.ReadString("Press [Enter] to navigate home");

            Program.NavigateBack();
        }

    }
}
