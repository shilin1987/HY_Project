using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_EmployeeInformationEntry.Models
{
    public class ApiModel
    {
        public ResponseCode code { get; set; }
        public string info { get; set; }
        public object data { get; set; }
        /// <summary>
        /// 辅助字段
        /// </summary>
        public string AuxiliaryField{ get; set; }
}
}