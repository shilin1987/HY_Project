using Learun.Application.Extention.TaskScheduling;
using Learun.Application.TwoDevelopment.Platform;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Plugin.HYIocInjection
{
    /// <summary>
    /// 定时调用方法
    /// </summary>
    public class RegularCalls : ITsMethod
    {
        /// <summary>
        /// 实现定时任务数据查看更新
        /// </summary>
        public  void Execute()
        {
            try
            {
                string url = ConfigurationManager.AppSettings["identificationCard"];
                string result = HttpHelper.Helper.GetURLReSource(url,null);
                //1.调用接口查看返回值
                if (!string.IsNullOrEmpty(result))
                {
                    ComparisonOfIdCardVerificationClassIBLL cocvIBLL = new ComparisonOfIdCardVerificationClassBLL();
                    cocvIBLL.SaveKeepIdCard(result);
                }
                else
                {
                    //根据返回值状态去对比

                  //  Root root = (Root)JsonNewtonsoft.FromJSON<Root>(result);
                }
                    

            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
    }
}
