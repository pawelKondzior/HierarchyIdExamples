using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples.Helpers.Menu.Base;
using HierarchyExamples62.Services;
using HierarchyExamples63.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{

    class EF63Page : BaseEFPage
    {
        public EF63Page(Program program)
            : base("Entity Framework 6.3", program)
        {

        }


        public override void Display()
        {
            ActionMenuPage.CurrentParentID = null;
            Program.NavigateTo<DisplayCategory>();
        }



        public override IDataService GetDataService()
        {
            return new DataServiceEF63();
        }
    }

    
}
