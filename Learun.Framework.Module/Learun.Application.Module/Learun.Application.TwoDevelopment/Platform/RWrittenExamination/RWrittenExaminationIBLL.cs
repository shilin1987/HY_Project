﻿using Learun.Util;
using System.Data;
using System.Collections.Generic;
using Learun.DataBase.Repository;
using Learun.Application.Organization.ReturnModel;

namespace Learun.Application.TwoDevelopment.Platform
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-31 10:54
    /// 描 述：RWrittenExamination
    /// </summary>
    public interface RWrittenExaminationIBLL
    {
        #region 获取数据

        /// <summary>
        /// 获取列表数据
        /// <summary>
        /// <returns></returns>
        IEnumerable<Hy_Recruit_WrittenExaminationEntity> GetList( string queryJson );
        /// <summary>
        /// 获取列表分页数据
        /// <param name="pagination">分页参数</param>
        /// <summary>
        /// <returns></returns>
        IEnumerable<WrittenExaminationEntityDTO> GetPageList(Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        Hy_Recruit_WrittenExaminationEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 删除实体数据
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon DeleteEntity(string keyValue);
        /// <summary>
        /// 保存实体数据（新增、修改）
        /// <param name="keyValue">主键</param>
        /// <summary>
        /// <returns></returns>
        ReturnCommon SaveEntity(string keyValue, WrittenExaminationEntityDTO entity);
        /// <summary>
        /// 身份验证成功流程生成下一条数据
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        ReturnCommon NodeSaveEntity(IRepository db, string keyValue, Hy_Recruit_WrittenExaminationEntity entity);


        ReturnCommon ResetInfo(string keyValue);
        #endregion

    }
}
