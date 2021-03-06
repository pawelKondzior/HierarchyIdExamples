﻿using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Menu.Actions;

namespace HierarchyExamples.Menu.Base
{
    public abstract class BaseMenuPage : MenuPage
    {
        protected IDataService DataService { get; set; }

        public BaseMenuPage(string name, Program program, params Option[] options)
            : base(name, program, options)
        {
        }

        protected void AddPages()
        {
            this.Program.AddPage(new AddCategoryPage(DataService, this.Program));
            this.Program.AddPage(new DisplayListPage(DataService, this.Program));
            this.Program.AddPage(new DisplayCategory(DataService, this.Program));
        }
    }
}