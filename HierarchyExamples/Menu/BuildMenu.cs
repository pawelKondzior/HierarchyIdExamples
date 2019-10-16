using EasyConsole;

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