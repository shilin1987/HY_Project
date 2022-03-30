using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.B2B_Code.B2B_CUST_ORDER_CHECK
{
    public class B2BResult
    {
        public string Code { get; set; }
        public string Msg { get; set; }
        public List<B2BResultSub> MsgDet { get; set; }
    }
}
