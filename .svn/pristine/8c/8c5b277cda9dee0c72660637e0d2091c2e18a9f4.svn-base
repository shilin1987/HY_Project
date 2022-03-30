using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_WorkPermitModule
{
    public class WorkingCertificateBLL : WorkingCertificateIBLL
    {
        WorkingCertificateService wcService = new WorkingCertificateService();
        public ReturnComment InsertListEntity(string jsonStr, string userId)
        {
            try
            {
                return wcService.SaveInfo(jsonStr, userId);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
    }
}
