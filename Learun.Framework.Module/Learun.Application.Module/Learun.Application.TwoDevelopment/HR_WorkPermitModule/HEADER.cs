using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_WorkPermitModule
{
    public class HEADER
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string xm { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string xb { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string bm { get; set; }
        /// <summary>
        /// 员工编码
        /// </summary>
        public string F_UserID { get; set; }
        /// <summary>
        /// 工序
        /// </summary>
        public string F_FourLevelOrganization { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string F_PostID { get; set; }
        /// <summary>
        /// 上岗日期
        /// </summary>
        public string F_Entrydate { get; set; }
        /// <summary>
        /// 考核日期
        /// </summary>
        public string F_AssessmentDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? F_writtenExamination { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? F_OperationCapability { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? F_workingAttitude { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? F_Responsibility { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? F_SUM { get; set; }
        /// <summary>
        /// 考核结果
        /// </summary>
        public string F_AssessmentResults { get; set; }
        /// <summary>
        /// 未考核/不合格原因
        /// </summary>
        public string F_ReasonDescription { get; set; }
        /// <summary>
        /// 部门/工序BPM
        /// </summary>
        public string F_OperationBPM { get; set; }
        /// <summary>
        /// 部门/工序主管
        /// </summary>
        public string F_OperationDirector { get; set; }
        /// <summary>
        /// 部门负责人
        /// </summary>
        public string F_OperationCharge { get; set; }
        /// <summary>
        /// 品质管理部
        /// </summary>
        public string F_QualityManagement { get; set; }
        /// <summary>
        /// 人力资源部
        /// </summary>
        public string F_HumanResources { get; set; }
        /// <summary>
        /// 表单号
        /// </summary>
        public string F_NO { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_PersonnelCategory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string F_Education { get; set; }
        /// <summary>
        /// 试用期限
        /// </summary>
        public string F_ProbationPeriod { get; set; }
        /// <summary>
        /// 具有岗位一级技能 结果
        /// </summary>
        public string F_OneAssessmentResults { get; set; }
        /// <summary>
        /// 具有岗位二级技能 结果
        /// </summary>
        public string F_TwoAssessmentResults { get; set; }
        /// <summary>
        /// 具有岗位三级技能 结果
        /// </summary>
        public string F_ThreeAssessmentResults { get; set; }
        /// <summary>
        /// 具有岗位四级技能 结果
        /// </summary>
        public string F_FourAssessmentResults { get; set; }
        /// <summary>
        /// 具有岗位五级技能 结果
        /// </summary>
        public string F_FiveAssessmentResults { get; set; }
        /// <summary>
        /// 具有岗位六级级技能 结果
        /// </summary>
        public string F_SixAssessmentResults { get; set; }
        /// <summary>
        /// 具有岗位一级技能 原因
        /// </summary>
        public string F_OneReasonDescription { get; set; }
        /// <summary>
        /// 具有岗位二级技能 原因
        /// </summary>
        public string F_TwoReasonDescription { get; set; }
        /// <summary>
        /// 具有岗位三级技能 原因
        /// </summary>
        public string F_ThreeReasonDescription { get; set; }
        /// <summary>
        /// 具有岗位四级技能 原因
        /// </summary>
        public string F_FourReasonDescription { get; set; }
        /// <summary>
        /// 具有岗位五级技能 原因
        /// </summary>
        public string F_FiveReasonDescription { get; set; }
        /// <summary>
        /// 具有岗位六级技能 原因
        /// </summary>
        public string F_SixReasonDescription { get; set; }
    }
}
