using EasyConsole;

namespace HierarchyExamples.Menu
{
    internal class MainPage : MenuPage
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