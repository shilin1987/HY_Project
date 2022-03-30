﻿using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.Platform

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2021-12-30 14:19
    /// 描 述：人员入职流程
    /// </summary>
    public class Hy_Recruit_ProcessOperationEntity 
    {
        #region 实体成员
        /// <summary>
        /// 主键ID
        /// </summary>
        /// <returns></returns>
        [Column("ID")]
        public string ID { get; set; }
        /// <summary>
        /// 子流程外键
        /// </summary>
        /// <returns></returns>
        [Column("SUBPROCESSID")]
        public string SubProcessId { get; set; }
        /// <summary>
        /// 操作状态(1成功，-1失败，0未操作)
        /// </summary>
        /// <returns></returns>
        [Column("OPERATIONSTATUS")]
        public int? OperationStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        [Column("REMARK")]
        public string Remark { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        /// <returns></returns>
        [Column("OPERATIONCONTENT")]
        public string OperationContent { get; set; }
        /// <summary>
        /// 应聘者外键
        /// </summary>
        /// <returns></returns>
        [Column("CANDIDATESID")]
        public string CandidatesId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        /// <returns></returns>
        [Column("OPERATIONTIME")]
        public DateTime? OperationTime { get; set; }
        /// <summary>
        /// 操作人员id
        /// </summary>
        /// <returns></returns>
        [Column("Operator")]
        public string Operator { get; set; }
        
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.ID = Guid.NewGuid().ToString();
            this.OperationTime = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.Operator = userInfo.userId;

        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            this.ID = keyValue;
            this.OperationTime = DateTime.Now;
            UserInfo userInfo = LoginUserInfo.Get();
            this.Operator = userInfo.userId;
        }
        #endregion
    }
}

