using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class BaseService
    {
        //private ApiModel apiModel;
       // private readonly HYDatabaseEntities hYDatabase;
        public BaseService()
        {
            result = new ApiModel() { code = ResponseCode.fail,info=string.Empty };
            if (hYDatabase == null)
            {
                hYDatabase = new HYDatabaseEntities();
            }
        }

        public ApiModel result { get; set; }
        public HYDatabaseEntities hYDatabase { get; set; }
    }
}