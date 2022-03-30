using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.ReturnModel
{
 public   class ReturnCommon
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }

    public class ReturnCommon<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
