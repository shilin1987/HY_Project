using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.MonthlyVegetablePriceSubsidy
{
    public class MonthlyVegetablePriceSubsidyDTO
    {
        private string oid;
        private string user_code;
        private string user_name;
        private string monBreakfastTogether;
        private string monLunchTogether;
        private string monDinnerTogether;
        private string monSupperTogether;
        private string countMoney;

        public string Oid { get => oid; set => oid = value; }
        public string User_code { get => user_code; set => user_code = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string MonBreakfastTogether { get => monBreakfastTogether; set => monBreakfastTogether = value; }
        public string MonLunchTogether { get => monLunchTogether; set => monLunchTogether = value; }
        public string MonDinnerTogether { get => monDinnerTogether; set => monDinnerTogether = value; }
        public string MonSupperTogether { get => monSupperTogether; set => monSupperTogether = value; }
        public string CountMoney { get => countMoney; set => countMoney = value; }
    }
}
