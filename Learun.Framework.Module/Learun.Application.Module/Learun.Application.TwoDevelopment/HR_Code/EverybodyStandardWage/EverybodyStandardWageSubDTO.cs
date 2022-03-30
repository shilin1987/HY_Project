using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.EverybodyStandardWage
{
   public class EverybodyStandardWageSubDTO
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标准工资子项
        /// </summary>
        public string SubItem { get; set; }
        /// <summary>
        /// 子项费用
        /// </summary>
        public double SubCost { get; set; }

        /// <summary>
        /// 是否固定费用
        /// </summary>
        public int IsFixedCost { get; set; }
        /// <summary>
        /// 公式
        /// </summary>
        public string Formula { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
