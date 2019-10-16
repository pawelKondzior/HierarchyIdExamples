using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Menu.Actions;
using HierarchyExamples.Menu.Base;
using HierarchyExamples.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Menu
{
    class ParentChildPage : BaseEFPage
    {


        public ParentChildPage(Program program)
            : base("Parent/Child", program)
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
            return new ParentChildDataService(); 
        }
    }
}
