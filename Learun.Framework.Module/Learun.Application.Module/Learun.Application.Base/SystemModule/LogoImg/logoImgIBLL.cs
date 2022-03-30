using System.Collections.Generic;

namespace Learun.Application.Base.SystemModule
{

    /// <summary> 
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架 
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司 
    /// 创 建：超级管理员 
    /// 日 期：2018-07-30 14:53 
    /// 描 述：logo设置 
    /// </summary> 
    public interface LogoImgIBLL
    {
        #region 获取数据 
        /// <summary> 
        /// 获取列表数据 
        /// <summary> 
        /// <returns></returns> 
        IEnumerable<LogoImgEntity> GetList(string queryJson);
        /// <summary> 
        /// 获取实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        LogoImgEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取logo图片
        /// </summary>
        /// <param name="code">编码</param>
        void GetImg(string code);
        #endregion

        #region 提交数据 

        /// <summary> 
        /// 删除实体数据 
        /// <param name="keyValue">主键</param> 
        /// <summary> 
        /// <returns></returns> 
        void DeleteEntity(string keyValue);

        /// <summary> 
        /// 保存实体数据（新增、修改） 
        /// <param name="entity">实体</param> 
        /// <summary> 
        /// <returns></returns>
        void SaveEntity(LogoImgEntity entity);

        #endregion
    }
}
