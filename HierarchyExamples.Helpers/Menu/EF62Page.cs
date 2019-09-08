using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples62.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{
    class EF62Page : BaseMenuPage
    {

        

        public EF62Page(Program program)
            : base("Page 1", program)
        {
            
        }

        public override IDataService GetDataService()
        {
            return new DataServiceEF62(); 
        }
    }
}
