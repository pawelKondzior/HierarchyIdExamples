using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers;
using HierarchyExamples.Menu.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HierarchyExamples.Menu.Actions
{

    public class RemoveCategoryPage : ActionMenuPage
    {
        public RemoveCategoryPage(IDataService dataService, Program program)
            : base(dataService, "Remove category", program)
        {
        }

        public override void Display()
        {
            var topLevel = DataService.Get(CurrentParentID);
            if (string.IsNullOrEmpty(topLevel.Name))
            {
                var str = string.Format("Category name: {0}", topLevel.Name);
                Output.WriteLine(ConsoleColor.Green, str);
            }

            DisplayHelpers.WriteTable("Choose category to delete", topLevel.Childs);

            var itemToRemoveId = Input.ReadInt();

            var possibleIds = topLevel.Childs.Select(x => x.Id);

            if (possibleIds.Contains(itemToRemoveId))
            {
                DataService.Remove(itemToRemoveId);
                Output.WriteLine("Item deleted");
            }
            else
            {
                Output.DisplayPrompt("Item cannot be deleted");
            }

            Input.ReadString("Press [Enter] to navigate home");

            Program.NavigateBack();
        }

    }
}
