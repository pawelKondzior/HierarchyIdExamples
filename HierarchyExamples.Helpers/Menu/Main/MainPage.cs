using EasyConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    class MainPage : MenuPage
    {
        public MainPage(Program program)
           : base("MainPage", program,
                    new Option("EF62Page", () => program.NavigateTo<EF62Page>()),
                    new Option("EF63Page", () => program.NavigateTo<EF63Page>())
                 )
        {
        }
    }
}
