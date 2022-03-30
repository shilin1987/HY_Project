using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcess
{
    public class SRProcessExportDataDTO
    {
        private string f_HrIndicatesOrderNumber;
        private string f_ResumeName;
        private string f_WhetherThrough;
        private string f_ProcessTheOrder;
        private string f_OaFlowNumber;
        private string f_Approver;
        private string f_CheckpointName;
        private DateTime ? f_ApprovalDate;
        private string f_ApprovalResults;
        private string f_ApprovalComments;

        public string F_HrIndicatesOrderNumber { get => f_HrIndicatesOrderNumber; set => f_HrIndicatesOrderNumber = value; }
        public string F_ResumeName { get => f_ResumeName; set => f_ResumeName = value; }
        public string F_WhetherThrough { get => f_WhetherThrough; set => f_WhetherThrough = value; }
        public string F_ProcessTheOrder { get => f_ProcessTheOrder; set => f_ProcessTheOrder = value; }
        public string F_OaFlowNumber { get => f_OaFlowNumber; set => f_OaFlowNumber = value; }
        public string F_Approver { get => f_Approver; set => f_Approver = value; }
        public string F_CheckpointName { get => f_CheckpointName; set => f_CheckpointName = value; }
        public DateTime? F_ApprovalDate { get => f_ApprovalDate; set => f_ApprovalDate = value; }
        public string F_ApprovalResults { get => f_ApprovalResults; set => f_ApprovalResults = value; }
        public string F_ApprovalComments { get => f_ApprovalComments; set => f_ApprovalComments = value; }
    }
}
