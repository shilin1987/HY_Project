using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.Web.Areas.WebServerUtil
{
    public class MySoapHeader : System.Web.Services.Protocols.SoapHeader
    {
        private string userName;
        private string passWord;

        public MySoapHeader() { }
        public MySoapHeader(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }

        public string UserName
        {
            set
            {
                userName = value;
            }
            get
            {
                return userName;
            }
        }
        public string PassWord
        {
            set
            {
                passWord = value;
            }
            get
            {
                return passWord;
            }
        }
    }
}