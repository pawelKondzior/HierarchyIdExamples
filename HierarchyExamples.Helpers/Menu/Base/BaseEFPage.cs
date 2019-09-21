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
            DataService = GetDataService();


            program.AddPage(new DisplayFirstLevel(DataService, program));
            program.AddPage(new AddCategoryPage(DataService, program));
            program.AddPage(new DisplayListPage(DataService, program));
            program.AddPage(new DisplayCategory(DataService, program));
            program.AddPage(new RemoveCategoryPage(DataService, program));
            program.AddPage(new OpenCategoryPage(DataService, program));
        }


        public abstract IDataService GetDataService();

    }
}
