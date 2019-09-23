using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples.Helpers.Menu.Base;
using HierarchyExamples62.Services;
using HierarchyExamples63.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
       //     DataService = GetDataService();

        ///    base.Display();

       
            ActionMenuPage.CurrentParentID = null;
            Program.NavigateTo<DisplayCategory>();

            //var lastItem = Program.History.LastOrDefault(x => x.GetType() != this.GetType());
            //if (lastItem.GetType() == typeof(MainPage))
            //{
            //    Program.NavigateTo<DisplayCategory>();
            //}
            //else
            //{
            //    Program.NavigateTo<MainPage>();
            //}
        }



        public override IDataService GetDataService()
        {
            return new DataServiceEF63();
        }
    }

    
}
