using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemporaryPro_Web.Models
{
    public class ReturnCommon
    {
        private Boolean falg = true;
        private string meg = null;

        public bool Falg { get => falg; set => falg = value; }
        public string Meg { get => meg; set => meg = value; }
    }
}