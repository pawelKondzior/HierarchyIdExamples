using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers;
using HierarchyExamples.Menu.Base;

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

                  new Option("Main Menu", () => program.NavigateTo<MainPage>())

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