using Dapper;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.DataBase.Repository;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-10 11:29
    /// 描 述：标准工资维护
    /// </summary>
    public class StandardWageService : RepositoryFactory
    {
        ReturnCommon _return;
        public StandardWageService()
        {
            _return = new ReturnCommon();
        }

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_StandardWageEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ID,
                t.F_ItemId,
                t.F_ParentItemId,
                t.F_IsFixedCost,
                t.F_Cost,
                t.F_EnabledMark,
                t.F_Formula
                ");
                strSql.Append("  FROM Hy_hr_StandardWage t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
                {
                    dp.Add("startTime", queryParam["StartTime"].ToDate(), DbType.DateTime);
                    dp.Add("endTime", queryParam["EndTime"].ToDate(), DbType.DateTime);
                    strSql.Append(" AND ( t.F_CreateDate >= @startTime AND t.F_CreateDate <= @endTime ) ");
                }
                if (!queryParam["F_ItemId"].IsEmpty())
                {
                    dp.Add("F_ItemId", queryParam["F_ItemId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ItemId = @F_ItemId ");
                }
                if (!queryParam["F_ParentItemId"].IsEmpty())
                {
                    dp.Add("F_ParentItemId", queryParam["F_ParentItemId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ParentItemId = @F_ParentItemId ");
                }
                if (!queryParam["F_IsFixedCost"].IsEmpty() && queryParam["F_IsFixedCost"].ToString()!= "undefined")
                {
                    dp.Add("F_IsFixedCost", queryParam["F_IsFixedCost"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_IsFixedCost = @F_IsFixedCost ");
                }
                if (!queryParam["F_Cost"].IsEmpty())
                {
                    dp.Add("F_Cost", "%" + queryParam["F_Cost"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Cost Like @F_Cost ");
                }
                if (!queryParam["F_Formula"].IsEmpty())
                {
                    dp.Add("F_Formula", "%" + queryParam["F_Formula"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Formula Like @F_Formula ");
                }
                return this.BaseRepository().FindList<Hy_hr_StandardWageEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取Hy_hr_StandardWage表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_StandardWageEntity GetHy_hr_StandardWageEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_StandardWageEntity>(keyValue);
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
                var isDel = this.BaseRepository().Delete<Hy_hr_StandardWageEntity>(t => t.F_ID == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_StandardWageEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_StandardWageEntity>(t => t.F_ParentItemId == entity.F_ParentItemId && t.F_ItemId == entity.F_ItemId);
                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_ID != keyValue)
                    {
                        _return.Status = false;
                        _return.Message = "已存在相同数据";
                        return _return;
                    }
                    else
                    {
                        entity.Modify(keyValue);
                        addOrEdit = this.BaseRepository().Update(entity);
                    }
                }
                //添加
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
                        entity.Create();
                        addOrEdit = this.BaseRepository().Insert(entity);
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
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="state">状态：1-启动；0-禁用</param>
        public void UpdateState(string keyValue, int state)
        {
            try
            {
                Hy_hr_StandardWageEntity standardwage = new Hy_hr_StandardWageEntity();
                standardwage.Modify(keyValue);
                standardwage.F_EnabledMark = state;
                this.BaseRepository().Update(standardwage);
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
