using EasyConsole;
using HierarchyExamples.Helpers.Menu.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    public class BuildMenu : Program
    {
        public BuildMenu()
          : base("Menu", breadcrumbHeader: true)
        {
            AddPage(new MainPage(this));
            AddPage(new EF62Page(this));
            AddPage(new EF63Page(this));

            SetPage<MainPage>();
        }
    }
}
