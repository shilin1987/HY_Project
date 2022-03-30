using Learun.Application.TwoDevelopment.ReturnModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.Utils.Impl
{
    public class ImplControlClosingTime : ControlClosingTime
    {

        private CloseFinancialLedgerService closeFinancialLedgerService = new CloseFinancialLedgerService();
        /// <summary>
        /// time:2021-08-23
        /// function:判断结账时间
        /// author：cz
        /// </summary>
        /// <returns></returns>


        ReturnCommon ControlClosingTime.JudgeCurrentTime(DateTime date)
        {
            string closeTime = "";
            DateTime currentTime = DateTime.Now;////2005-11-5 13:21:25 
            int year = currentTime.Month;
            int month = currentTime.Month;
            //处理月份减一个月
            if (month == 1)
            {
                month = 12;
                year -= 1;
            }
            else
            {
                month -= 1;
            }


            ReturnCommon rc = new ReturnCommon();
            //1.查询结账时间和系统时间做判断
            IEnumerable<Hy_hr_CloseFinancialLedgerEntity> data = closeFinancialLedgerService.GetPagehcf().Where(e => e.F_CloseTime != null);
            var closeDate = data.ToList();
            if (closeDate.Count > 0)
            {
                closeTime = closeDate[0].F_CloseTime;
            }
            string[] timevale = closeTime.Split('-');
            string closeTimeStand = year + "-" + month + "-" + timevale[0] + " " + timevale[1] + ":" + timevale[2] + ":" + timevale[3];
            //dt.Year.ToString();//2005 

            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd HH:mm:ss";
            DateTime dt = Convert.ToDateTime(closeTimeStand, dtFormat);
            Console.WriteLine(dt.ToShortDateString());
            int compNum = DateTime.Compare(dt, date);

            //传进时间大于关账时间
            if (compNum < 0)
            {
                rc.Status = true;
            }
            else
            {
                rc.Status = false;
                rc.Message = "当前编辑数据已经关账，不能修改";
            }
            return rc;
        }
    }
}
