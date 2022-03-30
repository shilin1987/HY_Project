using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlySettlementsFormulaToCalculate
{
    public class ReturnCommonMeg
    {
        private Boolean flag = false;
        private string meg;
        private DataStorageDTO data;
        public ReturnCommonMeg()
        {
       
        }
        public ReturnCommonMeg(DataStorageDTO data)
        {
            this.data = data;
        }

        public bool Flag { get => flag; set => flag = value; }
        public string Meg { get => meg; set => meg = value; }
        public DataStorageDTO Data { get => data; set => data = value; }
    }

}
