﻿using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.Organization;
using System.Linq;
namespace Learun.Application.TwoDevelopment.HR_Code
{


    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-10-11 10:41
    /// 描 述：个人标准工资明细
    /// </summary>
    public class IndividualStandardItemBLL : IndividualStandardItemIBLL
    {
        private IndividualStandardItemService individualStandardItemService = new IndividualStandardItemService();
        private UserIBLL userIBLL = new UserBLL();
        private PostLevelIBLL plIBLL = new PostLevelBLL();
        #region 获取数据

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hr_personalStandards_fileEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return individualStandardItemService.GetPageList(pagination, queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f_userid"></param>
        /// <returns></returns>
        public IEnumerable<Hr_personalStandards_fileEntity> GetList(string f_userid)
        {
            try
            {
                return individualStandardItemService.GetPageList(f_userid);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }


        /// <summary>
        /// 根据员工编号获取数据
        /// </summary>
        /// <param name="F_userId"></param>
        /// <returns></returns>
        public void  GetHrStandardList(string F_userId,decimal standtardMoney, decimal f_ps16, decimal f_ps17)
        {
            try
            {
                //1.根据员工工号获取员工f_userid和员工的岗级
                UserEntity user = userIBLL.GetEntityByAccount(F_userId);
                //2.根据岗级查询岗级对应相关工资
                var data = plIBLL.GetPostLevelEntityList(user.F_SalaryMethod).ToList()[0];
                //3更新对应的实体
                Hr_personalStandards_fileEntity entity = new Hr_personalStandards_fileEntity();
                entity.F_ps01 = Guid.NewGuid().ToString();
                entity.F_CreateDate = DateTime.Now;
                UserInfo userInfo = LoginUserInfo.Get();
                entity.F_CreateUserId = userInfo.userId;
                entity.F_CreateUserName = userInfo.realName;
                entity.F_ps02 = user.F_UserId;
                entity.f_ps03= user.F_RealName;
                entity.f_ps04 = data.F_BasePay;
         
                entity.f_ps06 = data.F_ManagementSkillSalary;
                entity.f_ps07 = 200;
                entity.f_ps08 = data.F_TransportationSubsidy;
                entity.f_ps09 = data.F_HousingSubsidy;
                entity.f_ps10 = data.F_DutyAllowance;
                entity.f_ps11 = 0;
                entity.f_ps12 = data.F_MissedMealAllowance;
                entity.f_ps13 = user.F_SalaryMethod;
                entity.f_ps14 = Convert.ToDecimal(Math.Round(((decimal)(standtardMoney - data.F_MissedMealAllowance) * (decimal)data.F_PerformancePay),2).ToString("#0.00"));
                entity.f_ps15 = standtardMoney;
                entity.f_ps05 = standtardMoney - data.F_BasePay - data.F_ManagementSkillSalary - 200 - data.F_ManagementSkillSalary - data.F_TransportationSubsidy - data.F_HousingSubsidy - data.F_DutyAllowance - data.F_MissedMealAllowance - (standtardMoney - data.F_MissedMealAllowance) * data.F_PerformancePay;
                entity.f_ps16 = f_ps16;
                entity.f_ps17 = f_ps17;
                individualStandardItemService.SaveEntity("", entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        /// <summary>
        /// 获取Hr_personalStandards_file表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hr_personalStandards_fileEntity GetHr_personalStandards_fileEntity(string keyValue)
        {
            try
            {
                return individualStandardItemService.GetHr_personalStandards_fileEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
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
                individualStandardItemService.DeleteEntity(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public void SaveEntity(string keyValue, Hr_personalStandards_fileEntity entity)
        {
            try
            {
                individualStandardItemService.SaveEntity(keyValue, entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }



        #endregion

    }
}
