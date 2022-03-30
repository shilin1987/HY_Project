using Learun.Util;
using System;
using System.Data;
using System.Collections.Generic;
using Learun.Application.TwoDevelopment.ReturnModel;
using Learun.Application.TwoDevelopment.HR_SocialRecruitment;
using Learun.Application.Organization;
using Learun.Cache.Base;
using Learun.Cache.Factory;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-06-28 14:04
    /// 描 述：岗级工资和基本工资维护
    /// </summary>
    public class SR_RecruitmentBLL : SR_RecruitmentIBLL
    {
        private SR_RecruitmentService RecruitmentService = new SR_RecruitmentService();
        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKeyOperator = "Learun_ADMS_6.1_PC";// +登录者token
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        public ReturnCommon DeleteEntity(string keyValue)
        {
            return RecruitmentService.DeleteEntity(keyValue);
        }

        /// <summary>
        /// 获取用户信息显示列表数据
        /// <summary>
        /// <param name="F_EnCode">用户编码</param>
        /// <returns></returns>
        public IEnumerable<UserEntityDTO> GetDepartmentList(string F_EnCode)
        {
            try
            {
                //List<UserEntity> list = cache.Read<List<UserEntity>>(cacheKeyOperator, CacheId.loginInfo);
                F_EnCode = cache.Read<string>(cacheKeyOperator, CacheId.loginInfo);
                return RecruitmentService.GetDepartmentList(F_EnCode);
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
        public ReturnCommon SaveEntity(SR_RecruitmentEntity entity)
        {
            return RecruitmentService.SaveEntity(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ReturnCommon UpdateEntity(SR_RecruitmentEntity entity)
        {
            return RecruitmentService.UpdateEntity(entity);
        }
        #endregion

    }
}
