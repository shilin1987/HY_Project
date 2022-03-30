using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.Common
{
    /// <summary>
    /// 计算表达式拆解
    /// </summary>
 public   interface IFormulaDisassembly
    {

        /// <summary>
        /// 由DataTable计算公式
        /// </summary>
        /// <param name="expression">表达式</param>
        double CalcByDataTable(string expression);

        /// <summary>
        ///  由Microsoft.Eval对象计算表达式，需要引用Microsoft.JScript和Microsoft.Vsa名字空间。
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        double CalcByJs(string expression);
    }
}
