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
    /// 日 期：2021-05-27 14:10
    /// 描 述：收支分类子项
    /// </summary>
    public class OperationItemsService : RepositoryFactory
    {

        ReturnCommon _return;

        public OperationItemsService()
        {
            _return = new ReturnCommon();
        }
 
        #region 获取数据
        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_OperationItemsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ItemId,
                t.F_ItemCode,
                t.F_Item,
                t.F_HRClassify,
                t.F_TableName,
                t.F_FiledName
                ");
                strSql.Append("  FROM Hy_hr_OperationItems t ");
                strSql.Append("  WHERE F_DeleteMark<>1  or t.F_DeleteMark is null");
                var queryParam = queryJson.ToJObject();
                // 虚拟参数
                var dp = new DynamicParameters(new { });
                if (!queryParam["F_ItemCode"].IsEmpty())
                {
                    dp.Add("F_ItemCode", "%" + queryParam["F_ItemCode"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_ItemCode Like @F_ItemCode ");
                }
                if (!queryParam["F_Item"].IsEmpty())
                {
                    dp.Add("F_Item", "%" + queryParam["F_Item"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_Item Like @F_Item ");
                }
                if (!queryParam["F_HRClassify"].IsEmpty())
                {
                    dp.Add("F_HRClassify", queryParam["F_HRClassify"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_HRClassify = @F_HRClassify ");
                }
                return this.BaseRepository().FindList<Hy_hr_OperationItemsEntity>(strSql.ToString(), dp, pagination);
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

        public IEnumerable<Hy_hr_OperationItemsEntity> GetList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_ItemId,
                t.F_ItemCode,
                t.F_Item,
                t.F_HRClassify,
                t.F_TableName,
                t.F_FiledName
                ");
                strSql.Append("  FROM Hy_hr_OperationItems t ");
                strSql.Append("  WHERE F_DeleteMark<>1  or t.F_DeleteMark is null");
             
                return this.BaseRepository().FindList<Hy_hr_OperationItemsEntity>(strSql.ToString());
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
        /// 获取Hy_hr_OperationItems表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_OperationItemsEntity GetHy_hr_OperationItemsEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_OperationItemsEntity>(keyValue);
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
                //逻辑删除
                var updateSql = string.Format("update  Hy_hr_OperationItems set F_DeleteMark=1   where F_ID='{0}'", keyValue);
                var isDel = this.BaseRepository().ExecuteBySql(updateSql);
               // var isDel = this.BaseRepository().Delete<Hy_hr_OperationItemsEntity>(t => t.F_ItemId == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_OperationItemsEntity entity)
        {
            try
            {
                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_OperationItemsEntity>(t => t.F_ItemCode == entity.F_ItemCode && t.F_Item == entity.F_Item && t.F_HRClassify == entity.F_HRClassify);

                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_ItemId != keyValue)
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
                } //添加
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
