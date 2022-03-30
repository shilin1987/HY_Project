using Dapper;
using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.HR_WorkPermitModule;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-11-30 09:14
    /// 描 述：上岗资格认证表
    /// </summary>
    public class WL_NormalShiftService : RepositoryFactory
    {
        #region 构造函数和属性

        private string fieldSql;
        public string F_EnCodes;
        ReturnComment _return;
        public WL_NormalShiftService()
        {
            fieldSql= @"
       t.F_EnabledMark,
                t.F_CreateUserId,
                t.F_ModifyUserName,
                t.F_ModifyUserId,
                t.F_DeleteMark,
                t.F_SortCode,
                t.F_ModifyDate,
                t.F_CreateUserName,
                t.F_CreateDate,
                t.F_Description,
                t.F_ID,
                t.F_UserID,
                u.F_FourLevelOrganization,
                u.F_Education,
                t.F_PersonnelCategory,
                t.F_AppointmentDate,
                t.F_ProbationPeriod,
                t.F_writtenExamination,
                t.F_OperationCapability,
                t.F_workingAttitude,
                t.F_Responsibility,
                t.F_SUM,
                t.F_OperationBPM,
                t.F_OperationDirector,
                t.F_OperationCharge,
                t.F_QualityManagement,
                t.F_HumanResources,
                t.F_NO,
                t.F_IsDownload,
                u.F_EnCode,
                u.F_RealName,
                u.F_Gender,
                d.F_FullName,
                o.F_State as F_States
            ";
            _return = new ReturnComment();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        public IEnumerable<Hy_Wl_NormalShiftEntity> GetList( string queryJson )
        {
            try
            {
                //参考写法
                //var queryParam = queryJson.ToJObject();
                // 虚拟参数
                //var dp = new DynamicParameters(new { });
                //dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Hy_Wl_NormalShift t ");
                return this.BaseRepository().FindList<Hy_Wl_NormalShiftEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        public IEnumerable<NormalShiftEntityDTO> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {

                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM Hy_Wl_NormalShift t left join lr_base_user u on t.f_userid=u.F_UserId left join lr_base_department d on u.F_TertiaryOrganization = d.F_DepartmentId left join dbo.Hy_Wl_OaReturnInfo o on t.f_no=o.f_no");
                strSql.Append("  WHERE 1=1  ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_EnCode"].IsEmpty())
                {
                    dp.Add("F_EnCode", "%" + queryParam["F_EnCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND u.F_EnCode Like @F_EnCode ");
                }
                if (!queryParam["F_FullName"].IsEmpty())
                {
                    dp.Add("F_FullName", "%" + queryParam["F_FullName"].ToString() + "%", DbType.String);
                    strSql.Append(" AND d.F_FullName Like @F_FullName ");
                }
                if (!queryParam["F_States"].IsEmpty())
                {
                    dp.Add("F_States", "%" + queryParam["F_States"].ToString() + "%", DbType.String);
                    strSql.Append(" AND o.F_States Like @F_States ");
                }
                return this.BaseRepository().FindList<NormalShiftEntityDTO>(strSql.ToString(),dp, pagination);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_Wl_NormalShiftEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_Wl_NormalShiftEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnComment UpdateEntity(Hy_Wl_NormalShiftEntity entity)
        {
            try
            {
                ReturnComment rc = new ReturnComment();
                int count =  this.BaseRepository().Update(entity);
                if (count > 0)
                {
                    rc.State = "S";
                    rc.Mes = "修改流程状态成功";
                }
                else
                {
                    rc.State = "F";
                    rc.Mes = "修改流程状态失败";
                }
                return rc;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 获取页面显示子表数据
        /// <summary>
        /// <param name="fno">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_Wl_OaReturnInfo_itemEntity> GetSubList(string fno)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                u.F_RealName as F_TheApprover,
                a.F_Opinion,
                a.F_ApprovalTime ,
                a.F_whetherthrough 
                ");
                strSql.Append("  from lr_base_user u , Hy_Wl_OaReturnInfo_item  a ,dbo.Hy_Wl_NormalShift ns");
                strSql.Append("  WHERE a.f_no='" + fno + "'   and ns.F_no=a.F_no and u.F_EnCode=a.F_TheApprover ");
                strSql.Append("  order by a.F_ApprovalTime ");
                return this.BaseRepository().FindList<Hy_Wl_OaReturnInfo_itemEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 获取信息
        /// <summary>
        /// <param name="fid">查询参数</param>
        /// <returns></returns>
        public IEnumerable<UserNormalShiftEntityDTO> GetUserNormalShiftList(string fid)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"u.*,ns.*");
                strSql.Append(" from  dbo.Hy_Wl_NormalShift as ns left  join lr_base_user as u on ns.F_UserID=u.F_UserId  ");
                strSql.Append("  WHERE ns.F_ID='" + fid + "'");
                var userNormalShiftModel = this.BaseRepository().FindList<UserNormalShiftEntityDTO>(strSql.ToString());
                var departmentModel = this.BaseRepository().FindList<DepartmentEntity>("select * from lr_base_department");
                var postModel = this.BaseRepository().FindList<PostEntity>("select * from lr_base_post");
                var OaReturnInfo = this.BaseRepository().FindList<Hy_Wl_OaReturnInfo_itemEntity>("select * from  Hy_Wl_OaReturnInfo_item i left join lr_base_user u on i.F_TheApprover=u.F_EnCode  where i.F_No=(select F_NO from Hy_Wl_NormalShift where F_ID='" + fid + "') and  i.F_NoNum<=4  order by i.F_NoNum");
                var newUserNormalShiftModel = from u in userNormalShiftModel
                                   select new UserNormalShiftEntityDTO
                                   {
                                       F_UserID = u.F_UserID,
                                       F_EnCode = u.F_EnCode,
                                       F_RealName = u.F_RealName,
                                       F_DateHoldingPost = u.F_DateHoldingPost,
                                       F_Education = u.F_Education,
                                       F_Gender = u.F_Gender == "1" ? "男" : "女",
                                       F_SecondaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).FirstOrDefault().F_FullName : "",
                                       F_TertiaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).FirstOrDefault().F_FullName : "",
                                       F_FourLevelOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).FirstOrDefault().F_FullName : "",
                                       F_PersonnelCategory=u.F_PersonnelCategory,
                                       F_AppointmentDate=u.F_AppointmentDate,
                                       F_ProbationPeriod=u.F_ProbationPeriod,
                                       F_writtenExamination=u.F_writtenExamination,
                                       F_OperationCapability=u.F_OperationCapability,
                                       F_workingAttitude=u.F_workingAttitude,
                                       F_Responsibility=u.F_Responsibility,
                                       F_SUM=u.F_SUM,
                                       F_OperationBPM= OaReturnInfo.Where(e => e.F_CheckpointName.Contains("BPM")).Count()>0 ? OaReturnInfo.Where(e => e.F_CheckpointName.Contains("BPM")).FirstOrDefault().F_RealName : "",
                                       F_OperationDirector= OaReturnInfo.Where(e => e.F_CheckpointName.Contains("部门主管")).Count()>0 ? OaReturnInfo.Where(e => e.F_CheckpointName.Contains("部门主管")).FirstOrDefault().F_RealName : "",
                                       F_OperationCharge = OaReturnInfo.Where(e => e.F_CheckpointName.Contains("部门负责人")).Count()>0 ? OaReturnInfo.Where(e => e.F_CheckpointName.Contains("部门负责人")).FirstOrDefault().F_RealName : "",
                                       F_QualityManagement = OaReturnInfo.Where(e => e.F_CheckpointName.Contains("品质管理")).Count()>0 ? OaReturnInfo.Where(e => e.F_CheckpointName.Contains("品质管理")).FirstOrDefault().F_RealName : "",
                                       F_HumanResources = OaReturnInfo.Where(e => e.F_CheckpointName.Contains("人力资源部审核")).Count()>0 ? OaReturnInfo.Where(e => e.F_CheckpointName.Contains("人力资源部审核")).FirstOrDefault().F_RealName : "",
                                       F_TrialDate =u.F_TrialDate

                                   };
                return newUserNormalShiftModel;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 获取用户信息
        /// <summary>
        /// <param name="F_EnCode">查询参数</param>
        /// <returns></returns>
        public IEnumerable<UserEntityDTO> GetUserList(string F_EnCode)
        {
            F_EnCodes = F_EnCode;
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"* ");
                strSql.Append("  from lr_base_user ");
                strSql.Append("  WHERE F_EnCode='" + F_EnCode + "'");
                var userModel= this.BaseRepository().FindList<UserEntity>(strSql.ToString());
                var departmentModel = this.BaseRepository().FindList<DepartmentEntity>("select * from lr_base_department");
                var postModel = this.BaseRepository().FindList<PostEntity>("select * from lr_base_post");
                var newUserModel = from u in userModel
                                   select new UserEntityDTO
                                   {
                                       F_UserId = u.F_UserId,
                                       F_EnCode = u.F_EnCode,
                                       F_RealName = u.F_RealName,
                                       F_Education = u.F_Education,
                                       F_PostId = postModel.Where(e => e.F_PostId == u.F_PostId).Count() > 0 ? postModel.Where(e => e.F_PostId == u.F_PostId).FirstOrDefault().F_Name : "",
                                       F_Gender = u.F_Gender == 1 ? "男" : "女",
                                       F_SecondaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_SecondaryOrganization).FirstOrDefault().F_FullName : "",
                                       F_TertiaryOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_TertiaryOrganization).FirstOrDefault().F_FullName : "",
                                       F_FourLevelOrganization = departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).Count() > 0 ? departmentModel.Where(e => e.F_DepartmentId == u.F_FourLevelOrganization).FirstOrDefault().F_FullName : "",
                                      
                                   };
                return newUserModel;
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
           
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void DeleteEntity(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete<Hy_Wl_NormalShiftEntity>(t=>t.F_ID == keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnComment SaveEntity(string keyValue, Hy_Wl_NormalShiftEntity entity)
        {
            try
            {
                ReturnComment rc = new ReturnComment();
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"* ");
                strSql.Append("  from lr_base_user ");
                strSql.Append("  WHERE F_EnCode='" + keyValue + "'");
                var userModel = this.BaseRepository().FindList<UserEntity>(strSql.ToString());
                entity.F_UserID = userModel.First().F_UserId;
                //重复提交
                var ChangeShifts = this.BaseRepository().FindEntity<Hy_Wl_NormalShiftEntity>(t => t.F_UserID == entity.F_UserID);
                if (ChangeShifts != null)
                {
                    _return.State = "false";
                    _return.Mes = "该员工已申请";
                    return _return;
                }
                else
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {

                        entity.Create();
                        entity.F_UserID = userModel.First().F_UserId;
                        entity.F_NO = "NS-" + DateTime.Now.ToString("yyMMdHHmmss");
                        entity.F_SUM = entity.F_writtenExamination + entity.F_OperationCapability + entity.F_workingAttitude + entity.F_Responsibility;
                        entity.F_IsDownload = "否";
                        int count = this.BaseRepository().Insert(entity);
                        if (count > 0)
                        {
                            WorkPermitModuleCreateOAIBLL<Hy_Wl_NormalShiftEntity> workPermitModuleCreateOABLL = new WorkPermitModuleCreateOABLL<Hy_Wl_NormalShiftEntity>();
                            rc = workPermitModuleCreateOABLL.crateOAandHRForm(entity);
                            if ("S".Equals(rc.State))
                            {
                                return rc;
                            }
                            else
                            {
                                return rc;
                            }
                        }
                        else
                        {
                            return rc;
                        }
                    }
                    return rc;
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }

        #endregion

    }
}
