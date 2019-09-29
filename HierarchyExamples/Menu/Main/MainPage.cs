using EasyConsole;
using HierarchyExamples.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Menu
{
    class MainPage : MenuPage
    {
        public MainPage(Program program)
           : base("Main Page", program,
                    new Option("Parent/Child approach", () => program.NavigateTo<ParentChildPage>()),
                    new Option("HierarchyId approach", () => program.NavigateTo<HierarchyIdPage>())
                 )
        {
        }

        
    }
}
