using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace HierarchyExamples.Helpers.Menu.Actions
{

    public class DisplayListPage : ActionMenuPage
    {
        public int? ParentId { get; set; }
        public bool Close { get; set; } 
        public DisplayListPage(IDataService dataService, Program program)
            : base(dataService, "DisplayListPage", program
                  //new Option("Page 1A", () => program.NavigateTo<Page1A>()),
                  ///new Option("Page 1B", () => program.NavigateTo<Page1B>())
                  )
        {

        }

        public override void Display()
        {
            var list = DataService.GetChilds(ParentId);

            var possibleIds = list.Select(x => x.Id);

            WriteTable("display top level", list);

            if (list.Any())
            {
                var intValue = Input.ReadInt();

                this.ParentId = intValue;
            }
            else
            {
                this.ParentId = null;
            }


            Input.ReadString("Press [Enter] to navigate");

            var dlp = Program.SetPage<DisplayListPage>();

            Input.ReadString("Press [Enter] to navigate home");

            Program.NavigateBack();
        }

    }
}
