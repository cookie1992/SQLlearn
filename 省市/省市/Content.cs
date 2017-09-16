using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 省市
{
     public class Content
    {
        public int did { get; set; }
        public int dtid { get; set; }
        public string dname { get; set; }
        public string content { get; set; }
        public override string ToString()
        {
            return this.dname;
        }
    }
}
