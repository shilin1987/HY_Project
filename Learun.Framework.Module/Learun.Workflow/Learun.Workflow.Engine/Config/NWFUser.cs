﻿namespace Learun.Workflow.Engine
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2018.11.13
    /// 描 述：流程人员信息
    /// </summary>
    public class NWFUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 公司主键
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId { get; set; }
        /// <summary>
        /// 标记 0需要审核1暂时不需要审核
        /// </summary>
        public int Mark { get; set; }
             
    }
}
