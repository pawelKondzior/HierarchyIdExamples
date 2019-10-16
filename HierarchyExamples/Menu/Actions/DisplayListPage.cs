using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers;
using HierarchyExamples.Menu.Base;
using System;
using System.Linq;

namespace HierarchyExamples.Menu.Actions
{
    public class DisplayListPage : ActionMenuPage
    {
        public int? ParentId { get; set; }
        public bool Close { get; set; }

        public DisplayListPage(IDataService dataService, Program program)
            : base(dataService, "DisplayListPage", program)
        {
        }

        public DisplayListPage(Func<IDataService> dataService, Program program)
            : base(dataService, "DisplayListPage", program)
        {
        }

        public override void Display()
        {
            var list = DataService.GetChilds(ParentId);

            var possibleIds = list.Select(x => x.Id);

            DisplayHelpers.WriteTable("display top level", list);

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