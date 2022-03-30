using Dapper;
using Learun.Application.Organization;
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
    /// 日 期：2021-07-05 16:13
    /// 描 述：奖惩费用维护
    /// </summary>
    public class RewardsPunishmentsService : RepositoryFactory
    {
        ReturnCommon _return;
        public RewardsPunishmentsService()
        {
            _return = new ReturnCommon();
        }


        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_RewardPunishmentEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(@"
                t.F_Id,
                t.F_UserId,
                t.F_ItemId,
                t.F_DateRewardPunishment,
                t.F_RewardorPunishment,
                t.F_Cost
                ");
                strSql.Append("  FROM Hy_hr_RewardPunishment t ");
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
                if (!queryParam["F_UserId"].IsEmpty())
                {
                    dp.Add("F_UserId", queryParam["F_UserId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_UserId = @F_UserId ");
                }
                if (!queryParam["F_ItemId"].IsEmpty())
                {
                    dp.Add("F_ItemId", queryParam["F_ItemId"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_ItemId = @F_ItemId ");
                }
                if (!queryParam["F_DateRewardPunishment"].IsEmpty())
                {
                    dp.Add("F_DateRewardPunishment", "%" + queryParam["F_DateRewardPunishment"].ToString() + "%", DbType.String);
                    strSql.Append(" AND t.F_DateRewardPunishment Like @F_DateRewardPunishment ");
                }
                if (!queryParam["F_RewardorPunishment"].IsEmpty())
                {
                    dp.Add("F_RewardorPunishment", queryParam["F_RewardorPunishment"].ToString(), DbType.String);
                    strSql.Append(" AND t.F_RewardorPunishment = @F_RewardorPunishment ");
                }
                return this.BaseRepository().FindList<Hy_hr_RewardPunishmentEntity>(strSql.ToString(), dp, pagination);
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
        /// 获取Hy_hr_RewardPunishment表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_RewardPunishmentEntity GetHy_hr_RewardPunishmentEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<Hy_hr_RewardPunishmentEntity>(keyValue);
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
                var isDel = this.BaseRepository().Delete<Hy_hr_RewardPunishmentEntity>(t => t.F_Id == keyValue);
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
        public ReturnCommon SaveEntity(string keyValue, Hy_hr_RewardPunishmentEntity entity)
        {
            try
            {
                //查找员工工号是否存在
                var isExistUser = this.BaseRepository().FindEntity<UserEntity>(t=>t.F_UserId==entity.F_UserId);
                if (isExistUser==null)
                {
                    _return.Status = false;
                    _return.Message = "员工工号不存在.";
                    return _return;
                }

                int addOrEdit = 0;
                var isExistItem = this.BaseRepository().FindEntity<Hy_hr_RewardPunishmentEntity>(t => t.F_ItemId == entity.F_ItemId && t.F_UserId == entity.F_UserId && t.F_DateRewardPunishment == entity.F_DateRewardPunishment);

                //修改
                if (!string.IsNullOrEmpty(keyValue))
                {
                    if (isExistItem != null && isExistItem.F_Id != keyValue)
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
                }//添加
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
