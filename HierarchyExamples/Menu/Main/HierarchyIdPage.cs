using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Menu.Actions;
using HierarchyExamples.Menu.Base;
using HierarchyExamples.Services;

namespace HierarchyExamples.Menu
{
    internal class HierarchyIdPage : BaseEFPage
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