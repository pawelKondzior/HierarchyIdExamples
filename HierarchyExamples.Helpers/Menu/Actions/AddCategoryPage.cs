using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu.Actions
{

    public class AddCategoryPage : ActionMenuPage
    {
        public AddCategoryPage(IDataService dataService, Program program)
            : base(dataService, "AddCategoryPage", program
                  //new Option("Page 1A", () => program.NavigateTo<Page1A>()),
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {

        }

        public override void Display()
        {
            // var topLevel = DataService.GetTopLevel();

            ///WriteTable("display top level", topLevel);


            var itemToAddStr = Input.ReadString("Enter name of new category:");

            if (!string.IsNullOrEmpty(itemToAddStr))
            {
                DataService.Add(new ProductCategoryDto
                {
                    Name = itemToAddStr
                }, null
                );
            }

            Input.ReadString("Press [Enter] to navigate home");

            //   base.Display();

            Program.NavigateBack();
            //Program.NavigateHome();
        }

    }
}
