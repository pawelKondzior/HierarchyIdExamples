using EasyConsole;
using HierarchyExamples.Helpers.Menu.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    class EF63Page : MenuPage
    {
        public EF63Page(Program program)
            : base("Page 2", program,
                  new Option("Display First Level", () => program.NavigateTo<DisplayFirstLevel>())
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {
        }
    }
}
