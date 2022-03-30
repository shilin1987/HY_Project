using Microsoft.VisualStudio.TestTools.UnitTesting;
using Learun.Application.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.Organization.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void GetVCodeTest()
        {
            UserService u = new UserService();
            var h=u.GetVCode("13000000000");
            Assert.Fail();
        }
    }
}