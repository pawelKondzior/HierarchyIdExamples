using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu.Actions
{

    public class AddCategoryPage : ActionMenuPage
    {
        public AddCategoryPage(IDataService dataService, Program program)
            : base(dataService, "Add New Category", program)
        {

        }

        public override void Display()
        {
            var itemToAddStr = Input.ReadString("Enter name of new category:");

            if (!string.IsNullOrEmpty(itemToAddStr))
            {
                var newCategoryDto = new ProductCategoryDto { Name = itemToAddStr };

                DataService.Add(newCategoryDto, CurrentParentID);
            }

            Program.NavigateTo<DisplayCategory>();
        }

    }
}
