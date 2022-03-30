using Learun.Application.TwoDevelopment.ReturnModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlySettlements
{
    /// <summary>
    /// function:计算月结算接口
    /// author：cz
    /// time：2021-09-08
    /// </summary>
    public interface MonthlySettlementsIBLL
    {
        /// <summary>
        /// 传入计算月的时间
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        ReturnCommon  monthlyCalculation(DateTime date);

        /// <summary>
        /// 计算时间为string
        /// </summary>
        /// <param name="computTime"></param>
        /// <returns></returns>
        ReturnCommon monthlyCalculation(string computTime);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ReturnCommon monthlyCalculation();
    }
}
