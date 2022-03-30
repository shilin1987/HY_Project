using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webAPI.Models
{
    public class RevisePasswordModel
    {
        public string userId { get; set; }
        public string newpassword { get; set; }
        public string oldpassword { get; set; }
    }
}