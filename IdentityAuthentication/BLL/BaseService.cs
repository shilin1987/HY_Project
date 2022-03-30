using IdentityAuthentication.Database;
using IdentityAuthentication.Models;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityAuthentication.BLL
{
    public class BaseService
    {
        public BaseService()
        {
            result = new ApiModel() { code = ResponseCode.fail };
            if (hYDatabase == null)
            {
                hYDatabase = new HYDatabaseEntities();
            }
            returnCommon = new ReturnCommon() { Status=false};
        }

        public ApiModel Log { get; set; }

        public ApiModel result { get; set; }
        public ReturnCommon returnCommon { get; set; }
        public HYDatabaseEntities hYDatabase { get; set; }

    }
}