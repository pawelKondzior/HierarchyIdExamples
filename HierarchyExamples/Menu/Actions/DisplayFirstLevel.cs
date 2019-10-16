using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers;
using HierarchyExamples.Menu.Base;

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