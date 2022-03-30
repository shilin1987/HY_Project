using Learun.Application.Organization;
using Learun.Application.TwoDevelopment.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_EmployeeInformationEntry.Models
{
    public class InterviewModele
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class ALLInterviewModele
    {
        public List<InterviewModele> InterviewModeleor { get; set; }
        public List<Hy_Recruit_InterviewQuestionBankEntity> InterviewQuestionBank { get; set; }

    }

}