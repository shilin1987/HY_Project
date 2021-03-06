using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.NewVegetablePrices
{
    public class VegetablePricesBLL : VegetablePricesIBLL
    {
        VegetablePricesService vegetablePricesService = new VegetablePricesService();
        public ReturnCommon CalculateVegetablePrice()
        {
            try
            {
                return vegetablePricesService.CalculateVegetablePrice();
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
        public ReturnCommon CalculateVegetablePriceDetil()
        {
            try
            {
                return vegetablePricesService.CalculateVegetablePriceDetil();
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
