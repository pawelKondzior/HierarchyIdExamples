using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples62.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    public abstract class BaseMenuPage : MenuPage
    {

        private IDataService DataService { get; set; }

        public BaseMenuPage(string name, Program program)
            : base(name, program,
                  new Option("Display First Level", () => program.NavigateTo<DisplayFirstLevel>()),
                  new Option("Add Category", () => program.NavigateTo<AddCategoryPage>()),
                  new Option("Display List", () => program.NavigateTo<DisplayListPage>())
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {
            DataService = GetDataService();


            program.AddPage(new DisplayFirstLevel(DataService, program));
            program.AddPage(new AddCategoryPage(DataService, program));
            program.AddPage(new DisplayListPage(DataService, program));
        }

        public abstract IDataService GetDataService();


    }
}
