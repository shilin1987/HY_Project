using Microsoft.VisualStudio.TestTools.UnitTesting;
using Learun.Application.WebApi.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.WebApi.Modules.Tests
{
    [TestClass()]
    public class PostApiTests
    {
        [TestMethod()]
        public void GetPostListTest()
        {
            UserApi user = new UserApi();
            PostApi postApi = new PostApi();
            postApi.GetPostList("");
            Assert.Fail();
        }
    }
}