using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples.Helpers.Menu.Base;
using HierarchyExamples62.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    class EF62Page : BaseEFPage
    {


        public EF62Page(Program program)
            : base("Entity Framework 6.2", program)
        {
           
        }

        public override void Display()
        {
            ActionMenuPage.CurrentParentID = null;
            Program.NavigateTo<DisplayCategory>();
        }

        public override IDataService GetDataService()
        {
            return new DataServiceEF62(); 
        }
    }
}
