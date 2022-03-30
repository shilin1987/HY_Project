﻿
namespace Learun.Application.WorkFlow
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2018.12.05
    /// 描 述：流程绑定方法需要继承的接口
    /// </summary>
    public interface IWorkFlowMethod
    {
        /// <summary>
        /// 流程绑定方法需要继承的接口
        /// </summary>
        /// <param name="parameter"></param>
        void Execute(WfMethodParameter parameter);
    }
}
