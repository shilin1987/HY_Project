using Dapper;
using Learun.Application.Organization.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-09-27 10:31
    /// 描 述：入职年龄规则设置
    /// </summary>
    public class AgeLimitService : RepositoryFactory
    {
        ReturnCommon _return;
        public AgeLimitService()
        {
            _return = new ReturnCommon();
        }
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Platform_AgeLimitEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_AgeLimitID,
                t.F_PostID,
                t.F_StartAge,
                t.F_EndAge
                ");
                strSql.Append("  FROM Hy_Recruit_AgeLimit t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PostID"].IsEmpty())
                {
                    dp.Add("F_PostID",queryParam["F_PostID"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PostID = @F_PostID ");
                }
                if (!queryParam["F_StartAge"].IsEmpty())
                {
                    dp.Add("F_StartAge", "%" + queryParam["F_StartAge"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_StartAge = @F_StartAge ");
                }
                if (!queryParam["F_EndAge"].IsEmpty())
                {
                    dp.Add("F_EndAge", "%" + queryParam["F_EndAge"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_EndAge = @F_EndAge ");
                }
                return this.BaseRepository().FindList<Platform_AgeLimitEntity>(strSql.ToString(),dp, pagination);
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
        /// 获取Platform_AgeLimit表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Platform_AgeLimitEntity GetPlatform_AgeLimitEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Platform_AgeLimitEntity>(keyValue);
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
        public ReturnCommon DeleteEntity(string keyValue)
        {
            try
            {
               var isDel=this.BaseRepository().Delete<Platform_AgeLimitEntity>(t=>t.F_AgeLimitID == keyValue);
                if (isDel > 0)
                {
                    _return.Status = true;
                    _return.Message = "删除成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "删除失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }
            return _return;
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, Platform_AgeLimitEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Platform_AgeLimitEntity>(t => t.F_StartAge == entity.F_StartAge && t.F_EndAge == entity.F_EndAge && t.F_PostID==entity.F_PostID);
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_AgeLimitID != keyValue)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        if (entity.F_EndAge<=entity.F_StartAge) 
                        {
                            _return.Status = false;
                            _return.Message = "结束年龄不能小于开始年龄";
                            return _return;
                        }
                        else { 
                        entity.Modify(keyValue);
                        addOrEdit = this.BaseRepository().Update(entity);
                        }
                    }
                }
                else
                {
                    if (isExistItem != null)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        if (entity.F_EndAge<-entity.F_StartAge)
                        {
                            _return.Status = false;
                            _return.Message = "结束年龄不能小于开始年龄";
                            return _return;
                        }
                        else
                        {
                            entity.Create();
                            addOrEdit = this.BaseRepository().Insert(entity);
                        }
                        
                    }
                }
                if (addOrEdit > 0)
                {
                    _return.Status = true;
                    _return.Message = "保存成功";
                }
                else
                {
                    _return.Status = false;
                    _return.Message = "保存失败";
                }
            }
            catch (Exception ex)
            {
                _return.Status = false;
                _return.Message = ex.Message;
            }
            return _return;
        }

        #endregion

    }
}
