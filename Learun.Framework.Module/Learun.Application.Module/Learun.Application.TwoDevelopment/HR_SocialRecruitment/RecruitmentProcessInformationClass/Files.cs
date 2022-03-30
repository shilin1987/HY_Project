﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_SocialRecruitment.RecruitmentProcessInformationClass
{
    public class Files
    {
        private string f_fileName;
        private string f_file;
        private string state;
        private string f_Description;

        public Files()
        {
        }

        public Files(string f_fileName, string f_file, string state)
        {
            this.f_fileName = f_fileName;
            this.f_file = f_file;
            this.state = state;
        }

        public string F_fileName { get => f_fileName; set => f_fileName = value; }
        public string F_file { get => f_file; set => f_file = value; }
        public string State { get => state; set => state = value; }
        public string F_Description { get => f_Description; set => f_Description = value; }
    }
}
