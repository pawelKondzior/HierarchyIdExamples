using ConsoleTableExt;
using EasyConsole;
using HierarchyExamples.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HierarchyExamples.Helpers.Menu.Base
{
    public abstract class ActionMenuPage : BaseMenuPage
    {
        public static int? CurrentParentID { get; set; }

        public static string CurrentLevelIdP { get; set; }
        protected IDataService DataService { get; set; }

        

        public ActionMenuPage(IDataService dataService, string title, Program program, params Option[] options)
            : base(title, program, options)
        {
            DataService = dataService;
        }

        public ActionMenuPage(Func<IDataService> dataServiceFunc, string title, Program program, params Option[] options)
           : base(title, program, options)
        {
            ///DataService = dataService;
        }

        public void DispalyCurrentLevel()
        {

        }

       

        //public override void Display()
        //{
        //    base.Display();
        //}
    }
}
