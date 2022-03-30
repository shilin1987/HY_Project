using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.B2B_Code.CUST_ORDER_CREATE
{
   public class ListOrderParams
    {
        public string ParamName { get; set; }
        public string ParamDesc { get; set; }
        public string ParamType { get; set; }
        public string StrvalueList { get; set; }
        public List<string> valueList { get; set; }
        public string value { get; set; }
    }
}
