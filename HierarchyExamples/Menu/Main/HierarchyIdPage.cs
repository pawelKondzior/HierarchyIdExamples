using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Menu.Actions;
using HierarchyExamples.Menu.Base;
using HierarchyExamples.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HierarchyExamples.Menu
{

    class HierarchyIdPage : BaseEFPage
    {
        public HierarchyIdPage(Program program)
            : base("HierarchyId", program)
        {

        }

        public override void Display()
        {
            AddMyPages();
            ActionMenuPage.CurrentParentID = null;
            Program.NavigateTo<DisplayCategory>();
        }

        public override IDataService GetDataService()
        {
            return new HierarchyIdDataService();
        }
    }

    
}
