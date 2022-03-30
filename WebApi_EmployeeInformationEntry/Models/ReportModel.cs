using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_EmployeeInformationEntry.Models
{
    public class ReportModel
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 报到时间
        /// </summary>
        public string CheckInTime { get; set; }
    }
}