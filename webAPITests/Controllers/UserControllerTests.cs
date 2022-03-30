using Microsoft.VisualStudio.TestTools.UnitTesting;
using webAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void LoginTest()
        {

            UserController user = new UserController();

            LoginModel login = new LoginModel() { username = "system", password = "qwer1234" };
            user.Login(login);
            Assert.Fail();
        }
    }
}