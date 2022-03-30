using Learun.Util;
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
    public interface EverybodyStandardWageIBLL
    {
        #region 获取数据
        /// <summary>
        /// 根据用户userid查询标准工资
        /// </summary>
        /// <param name="f_userid">用户id</param>
        /// <returns></returns>
        IEnumerable<Hy_hr_EverybodyStandardWageEntity> GetHyPageList(string f_userid);

        /// <summary>
        /// 获取页面显示列表数据
        /// <summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        IEnumerable<Hy_hr_EverybodyStandardWageEntity> GetPageList(Pagination pagination, string queryJson);

        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="fid">标准工资主键</param>
        /// <returns></returns>
        IEnumerable<EverybodyStandardWageSubDTO> GetSubList(string fid, decimal fcost);
        /// <summary>
        /// 获取Hy_hr_EverybodyStandardWage表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_hr_EverybodyStandardWageEntity GetHy_hr_EverybodyStandardWageEntity(string keyValue);

        /// <summary>
        /// 获取Hy_hr_EverybodyStandardWageSub表实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_hr_EverybodyStandardWageSubEntity GetHy_hr_EverybodyStandardWageSubEntity(string keyValue);


        /// <summary>
        /// 获取Hy_hr_PostLevelEntity表实体数据
        /// <param name="UserId">用户ID</param>
        /// <summary>
        /// <returns></returns>
        Hy_hr_PostLevelEntity GetHy_hr_PostLevelEntityEntity(string UserId);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon DeleteEntity(string keyValue);

        /// <summary>
        /// 删除子项实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon DeleteSubEntity(string keyValue);

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon SaveEntity(string keyValue, string basePay, Hy_hr_EverybodyStandardWageEntity entity);

        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon SaveSubEntity(string isAdd, string keyValue, Hy_hr_EverybodyStandardWageSubEntity entity);
        #endregion

    }
}
