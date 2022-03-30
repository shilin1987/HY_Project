using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.WL_BaseService
{
 public   class MainSubProcessModel
    {
        /// <summary>
        /// 主流程ID
        /// </summary>
        public string MainProcessId { get; set; }
        /// <summary>
        /// 主流程名称
        /// </summary>
        public string MainProcessName { get; set; }
        /// <summary>
        /// 主流程排序
        /// </summary>
        public int MainprocessSort { get; set; }
        /// <summary>
        /// 子流程ID
        /// </summary>
        public string SubProcessId { get; set; }
        /// <summary>
        /// 子流程名称
        /// </summary>
        public string SubProcessName { get; set; }
        /// <summary>
        /// 子流程排序
        /// </summary>
        public int SubProcessSort { get; set; }
        /// <summary>
        /// 主流程备注
        /// </summary>
        public string MainProcessRemark { get; set; }
        /// <summary>
        /// 子流程备注
        /// </summary>
        public string SubProcessRemark { get; set; }
        /// <summary>
        /// 父项ID,支持无限扩展
        /// </summary>
        public string ParentId { get; set; }
    }
}
