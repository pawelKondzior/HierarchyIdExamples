using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyExamples.ConsoleItems
{
    public class MenuItem
    {
        public string Caption { get; set; }
        public Action Start { get; set; }
        public override string ToString()
        {
            return this.Caption.ToString();
        }
    }

}
