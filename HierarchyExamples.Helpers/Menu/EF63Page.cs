using EasyConsole;
using HierarchyExamples.Contracts;
using HierarchyExamples.Helpers.Menu.Actions;
using HierarchyExamples62.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyExamples.Helpers.Menu
{

    class EF63Page : BaseMenuPage
    {



        public EF63Page(Program program)
            : base("Page 2", program)
        {

        }

        public override IDataService GetDataService()
        {
            return new DataServiceEF62();
            //return new DataServiceEF63();
        }
    }

    
}
