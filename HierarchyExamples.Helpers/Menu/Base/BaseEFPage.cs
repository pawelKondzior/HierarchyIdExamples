using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples62.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu.Base
{
    public abstract class BaseEFPage : BaseMenuPage
    {

        public BaseEFPage(string name, Program program)
            : base(name, program)
                  
                  
        {
            AddMyPages();
        }

        public void AddMyPages()
        {
            DataService = GetDataService();

            Program.AddPage(new DisplayFirstLevel(DataService, Program));
            Program.AddPage(new AddCategoryPage(DataService, Program));
            Program.AddPage(new DisplayListPage(DataService, Program));
            Program.AddPage(new DisplayCategory(DataService, Program));
            Program.AddPage(new RemoveCategoryPage(DataService, Program));
            Program.AddPage(new OpenCategoryPage(DataService, Program));
            Program.AddPage(new AddProductsPage(DataService, Program));
        }

        public override void Display()
        {
          //  AddPages();

            base.Display();
        }

        public abstract IDataService GetDataService();

    }
}
