using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaoQinAndHRDataBasicsWService.Model
{
    public class UserModel
    {
        public string EnCode { get; set; }
        public string RealName { get; set; }
        public string Gender { get; set; }
        public string IDCard { get; set; }
        public string Post { get; set; }
        public string Mobile { get; set; }
        public string JobStatus { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime DateResignation { get; set; }
        /// <summary>
        /// 办理离职手续日期
        /// </summary>
        public string HandleResignationDate { get; set; }
    }
}
