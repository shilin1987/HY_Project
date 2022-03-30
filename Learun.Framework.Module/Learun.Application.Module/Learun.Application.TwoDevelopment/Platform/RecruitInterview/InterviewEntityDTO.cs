using Learun.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Learun.Application.TwoDevelopment.Platform

{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创 建：超级管理员
    /// 日 期：2022-01-12 15:16
    /// 描 述：面试信息
    /// </summary>
    public class InterviewEntityDTO
    {
        #region 实体成员
        /// <summary>
        /// 用户主键
        /// </summary>
        [Column("F_USERID")]
        public string F_UserId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column("F_REALNAME")]
        public string F_RealName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        [Column("F_MOBILE")]
        public string F_Mobile { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("F_IDCARD")]
        public string F_IDCard { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        [Column("F_EDUCATION")]
        public string F_Education { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Column("F_Gender")]
        public int? F_Gender { get; set; }
        /// <summary>
        /// 操作状态(1成功，-1失败，0未操作)
        /// </summary>
        /// <returns></returns>
        [Column("OPERATIONSTATUS")]
        public int? OperationStatus { get; set; }
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
        /// <summary>
        ///面试官id
        /// </summary>
        /// <returns></returns>
        [Column("F_Iuserid")]
        public string F_Iuserid { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            
        }
        #endregion
    }
}

