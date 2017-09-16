using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 省市
{
    public class category
    {
        public int tid { get; set; }
        public string tname { get; set; }
        public int tparentid  { get; set; }
        public override string ToString()
        {
            return this.tname; 
        }
    }
}
