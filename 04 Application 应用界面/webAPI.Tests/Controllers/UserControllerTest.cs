using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using webAPI.Controllers;
using webAPI.Models;

namespace webAPI.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserController user = new UserController();

            LoginModel login = new LoginModel() {username="system",password= "qwer1234" };
            user.Login(login);
        }
    }
}
