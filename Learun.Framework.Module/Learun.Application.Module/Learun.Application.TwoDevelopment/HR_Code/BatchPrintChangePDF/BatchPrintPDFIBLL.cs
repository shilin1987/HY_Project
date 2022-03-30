using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.BatchPrintChangePDF
{
    public interface BatchPrintPDFIBLL
    {
        /// <summary>
        /// 返回字节流
        /// </summary>
        /// <param name="bsowpList"></param>
        /// <returns></returns>
        byte[] getBatchPrintPdf(List<BothSidesOfWorkPermitDTO> bsowpList);
    }
}
