using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcessInformationClass
{
    public class OaProssInfoDTO
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        public string F_ID { get; set; }
        /// <summary>
        /// HR招聘流程单号
        /// </summary>
        /// <returns></returns>
        public string F_HrIndicatesOrderNumber { get; set; }

        /// <summary>
        /// OA流程单号
        /// </summary>
        /// <returns></returns>
        public string F_OaFlowNumber { get; set; }

        /// <summary>
        /// OArequestid
        /// </summary>
        /// <returns></returns>
        public string F_Requestid { get; set; }

        /// <summary>
        /// 归档时间
        /// </summary>
        /// <returns></returns>
        public DateTime? F_ArchiveTime { get; set; }

        /// <summary>
        /// 流程状态
        /// </summary>
        public string F_State { get; set; }
        /// <summary>
        /// 流程节点顺序
        /// </summary>
        public decimal ? F_ProcessTheOrder { get; set; }


        //子节点信息
        public List<ProcessNode> processNode;

        public List<Files> files;
    }
}
