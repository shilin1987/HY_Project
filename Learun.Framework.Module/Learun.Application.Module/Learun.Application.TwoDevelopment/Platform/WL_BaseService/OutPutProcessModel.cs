using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.WL_BaseService
{
  public  class OutPutProcessModel
    {
        /// <summary>
        /// 上一个流程
        /// </summary>
        public int PreviousProcessId { get; set; }
        public string PreviousProcessName { get; set; }
       // public string PreviousProcessCreationTime { get; set; }
        /// <summary>
        /// 下一个流程
        /// </summary>
        public int NextProcessId { get; set; }
        public string NextProcessName { get; set; }
      //  public int NextProcessCreationTime { get; set; }
    }
}
