using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.BatchPrintChangePDF
{
    public class BatchPrintPDFBLL : BatchPrintPDFIBLL
    {
        BatchPrintService bps = new BatchPrintService();
        public byte[] getBatchPrintPdf(List<BothSidesOfWorkPermitDTO> bsowpList)
        {
            try
            {
                return bps.getBatchPrintPdfService(bsowpList);
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
