using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class ApiModel
    {
        public ResponseCode code { get; set; }
        public string info { get; set; }
        public object data { get; set; }
    }
}