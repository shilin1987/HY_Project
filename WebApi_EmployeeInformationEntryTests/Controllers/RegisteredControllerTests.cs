using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi_EmployeeInformationEntry.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_EmployeeInformationEntry.Models;

namespace WebApi_EmployeeInformationEntry.Controllers.Tests
{
    [TestClass()]
    public class RegisteredControllerTests
    {
        [TestMethod()]
        public void SaveFormTest()
        {
            var tt = new RegisteredController();

            var registered = new RegisteredViewModel() 
            {
               IdCard = "32154646468454546",
               Name = "sdfds",
               Education = "dfs",
               RecruitmentChannels = "sdfsd",
               InternalCode = "sdfs",
               InternalName = "",
               InternalCompany = "",
               ExpectedentryDate = "",
               RecruitmentCompany ="",
               Mobile = "1357678787",
            };

            tt.SaveForm(registered);
            Assert.Fail();
        }
    }
}