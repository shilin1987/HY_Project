using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    /// <summary>
    /// 记录日志
    /// </summary>
    public class LogService : BaseService
    {
        /// <summary>
        /// 暂时用来面试官登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public ApiModel SaveLog(lr_base_log log)
        {
            hYDatabase.lr_base_log.Add(log);
            result.code = hYDatabase.SaveChanges() > 0 ? ResponseCode.success : ResponseCode.fail;
            return result;
        }
    }
}