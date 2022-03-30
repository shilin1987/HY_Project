using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_EmployeeInformationEntry.Models
{
    public class WrittenExaminationResult
    {
        /// <summary>
        /// 笔试结果
        /// </summary>
        public int wresult { get; set; }
        /// <summary>
        /// 应聘者ID
        /// </summary>
        public string candidatesId { get; set; }
    }
}