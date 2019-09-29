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

    public class DisplayCategory : ActionMenuPage
    {
        public DisplayCategory(IDataService dataService, Program program)
            : base(dataService, "Display Category", program,
                  new Option("Add Category", () => program.NavigateTo<AddCategoryPage>()),
                  new Option("Remove Category", () => program.NavigateTo<RemoveCategoryPage>()),
                  new Option("Open Category", () => program.NavigateTo<OpenCategoryPage>()),
                  new Option("Add Products to current category", () => program.NavigateTo<AddProductsPage>()),
                  //new Option("Display First Level", () => program.NavigateTo<DisplayFirstLevel>()),
                  
                  //new Option("Display List", () => program.NavigateTo<DisplayListPage>()),
                  //new Option("Display category", () => program.NavigateTo<DisplayCategory>()),
                  new Option("Main Menu", () => program.NavigateTo<MainPage>())
                  //new Option("Page 1A", () => program.NavigateTo<Page1A>()),
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {

        }

        public override void Display()
        {
            var topLevel = DataService.Get(CurrentParentID);
            DisplayHelpers.Display(topLevel);

            base.Display();
        }

    }
}
