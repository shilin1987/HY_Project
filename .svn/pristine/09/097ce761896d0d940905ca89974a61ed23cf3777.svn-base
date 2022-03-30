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
    /// 日 期：2021-05-26 11:59
    /// 描 述：收入支出详细
    /// </summary>
    public class IncomePayService : RepositoryFactory
    {

        ReturnCommon _return;
        public IncomePayService()
        {
            _return = new ReturnCommon();
        }

        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_OperationRelationEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_OperationRelationId,
                t.F_PayerUserId,
                t.F_OperationDate,
                t.F_Operation_Id,
                t.F_Formula,
                t.F_Cost,
                t.F_EnabledMark
                ");
                strSql.Append("  FROM Hy_hr_OperationRelation t ");
                strSql.Append("  WHERE 1=1 ");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_PayerUserId"].IsEmpty())
                {
                    dp.Add("F_PayerUserId", queryParam["F_PayerUserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_PayerUserId = @F_PayerUserId ");
                }
                if (!queryParam["F_OperationDate"].IsEmpty())
                {
                    dp.Add("F_OperationDate", "%" + queryParam["F_OperationDate"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_OperationDate Like @F_OperationDate ");
                }
                if (!queryParam["F_Operation_Id"].IsEmpty())
                {
                    dp.Add("F_Operation_Id", queryParam["F_Operation_Id"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Operation_Id = @F_Operation_Id ");
                }
                if (!queryParam["F_Formula"].IsEmpty())
                {
                    dp.Add("F_Formula", queryParam["F_Formula"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_Formula = @F_Formula ");
                }
                if (!queryParam["F_Cost"].IsEmpty())
                {
                    dp.Add("F_Cost", "%" + queryParam["F_Cost"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Cost Like @F_Cost ");
                }
                if (!queryParam["F_EnabledMark"].IsEmpty() && queryParam["F_EnabledMark"].ToString() != "undefined")
                {
                    dp.Add("F_EnabledMark", queryParam["F_EnabledMark"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_EnabledMark = @F_EnabledMark ");
                }
                return this.BaseRepository().FindList<Hy_hr_OperationRelationEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取Hy_hr_OperationRelation表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_OperationRelationEntity GetHy_hr_OperationRelationEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_OperationRelationEntity>(keyValue);
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
                var isDel = this.BaseRepository().Delete<Hy_hr_OperationRelationEntity>(t => t.F_OperationRelationId == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_OperationRelationEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_OperationRelationEntity>(t => t.F_PayerUserId == entity.F_PayerUserId && t.F_OperationDate == entity.F_OperationDate && t.F_Operation_Id==entity.F_Operation_Id);
                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_OperationRelationId != keyValue)
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

        #endregion

    }
}
