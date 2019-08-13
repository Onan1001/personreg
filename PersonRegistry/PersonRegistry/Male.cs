using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonRegistry
{
    public class Male : Person
    {
        public Male(string prefix, string firstname, string lastname) 
            : base(prefix, firstname, lastname)
        {
        }

        public override string GetFullNames()
        {
            return base.GetFullNames();
        }

    }  
}
