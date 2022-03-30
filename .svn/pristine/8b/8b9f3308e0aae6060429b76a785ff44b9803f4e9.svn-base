using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.Common
{
    /// <summary>
    /// 拆解表达式
    /// </summary>
    public class FormulaDisassembly : IFormulaDisassembly
    {
        /// <summary>
        /// 自动计算字符串公式
        /// 由DataTable计算公式
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        public double CalcByDataTable(string expression)
        {
            object result = new DataTable().Compute(expression, "");
            return double.Parse(result + "");
        }

        /// <summary>
        ///  由Microsoft.Eval对象计算表达式，需要引用Microsoft.JScript和Microsoft.Vsa名字空间。
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        [Obsolete]
        public double CalcByJs(string expression)
        {
            var ve = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
            object returnValue = Microsoft.JScript.Eval.JScriptEvaluate((object)expression, ve);
            return double.Parse(returnValue.ToString());
        }
    }
}
