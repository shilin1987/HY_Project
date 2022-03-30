using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.ReturnModel
{
    public class ReturnComment
    {
        private string state;
        private string mes;

        public string State { get => state; set => state = value; }
        public string Mes { get => mes; set => mes = value; }
    }
}
