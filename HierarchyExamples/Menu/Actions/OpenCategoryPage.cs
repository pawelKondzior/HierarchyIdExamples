using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers;
using HierarchyExamples.Menu.Base;
using System.Linq;

namespace HierarchyExamples.Menu.Actions
{
    public class OpenCategoryPage : ActionMenuPage
    {
        public OpenCategoryPage(IDataService dataService, Program program)
            : base(dataService, "Open category", program)
        {
        }

        public override void Display()
        {
            var topLevel = DataService.Get(CurrentParentID);
            DisplayHelpers.Display(topLevel, "Choose category to open");

            var selectedId = Input.ReadInt();

            var possibleIds = topLevel.Childs.Select(x => x.Id);

            if (possibleIds.Contains(selectedId))
            {
                CurrentParentID = selectedId;
            }
            else
            {
                Output.DisplayPrompt("Item cannot be open");
            }

            Program.NavigateTo<DisplayCategory>();
        }
    }
}