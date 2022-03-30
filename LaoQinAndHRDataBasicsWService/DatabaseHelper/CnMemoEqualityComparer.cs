using LaoQinAndHRDataBasicsWService.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaoQinAndHRDataBasicsWService.DatabaseHelper
{
    public class CnMemoEqualityComparer : IEqualityComparer<lr_base_user>
    {
        public bool Equals(lr_base_user x, lr_base_user y) => x.F_IDCard == y.F_IDCard;
        public int GetHashCode(lr_base_user obj) => obj == null ? 0 : obj.ToString().GetHashCode();
    }
}
