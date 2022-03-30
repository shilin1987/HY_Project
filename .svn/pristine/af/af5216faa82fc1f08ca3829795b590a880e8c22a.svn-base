using Learun.Application.Organization;
using Learun.Cache.Base;
using Learun.Cache.Factory;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_EmployeeInformationEntry.DataBase;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.BLL
{
    public class DepartmentService:BaseService
    {
      
        private ICache redisCache;
        private  string cacheKey = "learun_adms_department_"; // +加部门主键

        public DepartmentService() 
        {
            redisCache = CacheFactory.CaChe();
        }

        public ApiModel map(string token, string data)
        {
            try
            {
                Dictionary<string, DepartmentModel> dic = redisCache.Read<Dictionary<string, DepartmentModel>>(cacheKey + "_dic", CacheId.department);
                if (dic == null)
                {
                    dic = new Dictionary<string, DepartmentModel>();

                    var sql = @"SELECT t.F_DepartmentId,t.F_CompanyId,t.F_ParentId,t.F_EnCode,t.F_FullName,t.F_ShortName,
                     t.F_Nature,t.F_Manager,t.F_OuterPhone,t.F_InnerPhone,t.F_Email,t.F_Fax,t.F_SortCode,
                     t.F_DeleteMark,t.F_EnabledMark,t.F_Description,t.F_CreateDate,t.F_CreateUserId,
                     t.F_CreateUserName,t.F_ModifyDate,t.F_ModifyUserId,t.F_ModifyUserName  FROM LR_Base_Department t
                     WHERE t.F_EnabledMark = 1 AND (t.F_DeleteMark = 0 or t.F_DeleteMark is null) ";

                    var list = hYDatabase.Database.SqlQuery<DepartmentEntity>(sql);
                    if (list.Count() > 0)
                    {
                        foreach (var item in list)
                        {
                            DepartmentModel model = new DepartmentModel()
                            {
                                companyId = item.F_CompanyId,
                                parentId = item.F_ParentId,
                                name = item.F_FullName
                            };
                            dic.Add(item.F_DepartmentId, model);
                            redisCache.Write(cacheKey + "dic", dic, CacheId.department);
                        }
                    }
                }

                string md5 = Md5Helper.Encrypt(dic.ToJson(), 32);
                if (md5 == data)
                {
                    result.code = ResponseCode.success;
                    result.info = "no update";
                }
                else
                {
                    var jsondata = new
                    {
                        data = dic,
                        ver = md5
                    };

                    result.code = ResponseCode.success;
                    result.info = "update";
                    result.data = jsondata;
                }
            }
            catch (Exception ex)
            {
                var jsondata = new
                {
                    data = "",
                    ver = ""
                };
                result.info = ex.Message;
                result.data = jsondata;
            }

            return result;
        }

    }
}