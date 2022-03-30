using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.Platform.RecruitReportNodeApprovalClass
{
    public class Hy_Recruit_ReportNodeApprovalDTO
    {
        #region 实体成员
        /// <summary>
        /// 有效标志0否1是
        /// </summary>

        public int? F_EnabledMark { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>

        public string F_CreateUserId { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>

        public string F_ModifyUserName { get; set; }
        /// <summary>
        /// 编辑人ID
        /// </summary>

        public string F_ModifyUserId { get; set; }
        /// <summary>
        /// 删除标记0否1是
        /// </summary>

        public int? F_DeleteMark { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>

        public int? F_SortCode { get; set; }
        /// <summary>
        /// 编辑日期
        /// </summary>

        public DateTime? F_ModifyDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>

        public string F_CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime? F_CreateDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>

        public string F_Description { get; set; }
        /// <summary>
        /// 主键
        /// </summary>

        public string F_ID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>

        public string F_UserId { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>

        public string F_UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>

        public string F_CardId { get; set; }
        /// <summary>
        /// 报道时间
        /// </summary>

        public DateTime? F_StoryTime { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>

        public int? F_WhetherTheAudit { get; set; }

        /// <summary>
        /// 所住宿舍
        /// </summary>

        public string F_DormitoryButton { get; set; }
        #endregion
        #region 扩展字段
        /// <summary>
        /// 性别
        /// </summary>
        public string F_Sex { get; set; }
        ///// <summary>
        ///// 联系方式
        ///// </summary>
        public string F_Contact { get; set; }
        ///// <summary>
        ///// 学历信息
        ///// </summary>
        public string F_EducationInformation { get; set; }

        ///// <summary>
        ///// 银行卡号
        ///// </summary>
        public string F_BankCardNumber { get; set; }
        ///// <summary>
        ///// 图片
        ///// </summary>
        public string F_HeadIcon { get; set; }

        ///// <summary>
        ///// 图片
        ///// </summary>
        public string F_NodeWhere { get; set; }
        #endregion
    }
}
