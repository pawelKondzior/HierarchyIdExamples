using EasyConsole;
using HierarchyExamples.Menu.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Menu
{
    public class BuildMenu : Program
    {
        public BuildMenu()
          : base("Menu", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new ParentChildPage(this));
            AddPage(new HierarchyIdPage(this));

            SetPage<MainPage>();
        }
    }
}
