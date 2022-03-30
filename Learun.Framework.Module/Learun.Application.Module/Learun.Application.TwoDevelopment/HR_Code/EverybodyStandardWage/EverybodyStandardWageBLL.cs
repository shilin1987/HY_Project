using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.TwoDevelopment.HR_Code.EverybodyStandardWage;

namespace Learun.Application.TwoDevelopment.HR_Code
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-15 10:19
    /// 描 述：个人标准工资维护
    /// </summary>
    public class EverybodyStandardWageBLL : EverybodyStandardWageIBLL
    {
        private EverybodyStandardWageService everybodyStandardWageService = new EverybodyStandardWageService();

        #region 获取数据

        public IEnumerable<Hy_hr_EverybodyStandardWageEntity> GetHyPageList(string f_userid)
        {
            try
            {
                return everybodyStandardWageService.GetHyPageList(f_userid);
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
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<Hy_hr_EverybodyStandardWageEntity> GetPageList(Pagination pagination, string queryJson)
        {
            try
            {
                return everybodyStandardWageService.GetPageList(pagination, queryJson);
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
        /// 标准工资子项目获取
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public IEnumerable<EverybodyStandardWageSubDTO> GetSubList(string fid, decimal fcost)
        {
            return everybodyStandardWageService.GetSubList(fid, fcost);
        }

        /// <summary>
        /// 获取Hy_hr_EverybodyStandardWage表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_EverybodyStandardWageEntity GetHy_hr_EverybodyStandardWageEntity(string keyValue)
        {
            try
            {
                return everybodyStandardWageService.GetHy_hr_EverybodyStandardWageEntity(keyValue);
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
        /// 根据用户ID链表找到岗级工资和基本工资
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Hy_hr_PostLevelEntity GetHy_hr_PostLevelEntityEntity(string userId)
        {
           return everybodyStandardWageService.GetHy_hr_PostLevelEntityEntity(userId);
        }

        /// <summary>
        /// 获取Hy_hr_EverybodyStandardWage表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public Hy_hr_EverybodyStandardWageSubEntity GetHy_hr_EverybodyStandardWageSubEntity(string keyValue)
        {
            try
            {
                return everybodyStandardWageService.GetHy_hr_EverybodyStandardWageSubEntity(keyValue);
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
        public ReturnCommon DeleteEntity(string keyValue)
        {
            return everybodyStandardWageService.DeleteEntity(keyValue);
        }

        /// <summary>
        /// 删除子项实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon DeleteSubEntity(string keyValue)
        {
            return everybodyStandardWageService.DeleteSubEntity(keyValue);
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveEntity(string keyValue, string basePay, Hy_hr_EverybodyStandardWageEntity entity)
        {
            return everybodyStandardWageService.SaveEntity(keyValue, basePay, entity);
        }

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon SaveSubEntity(string isAdd, string keyValue, Hy_hr_EverybodyStandardWageSubEntity entity)
        {
            return everybodyStandardWageService.SaveSubEntity(isAdd,keyValue, entity);
        }



        #endregion

    }
}
