using Microsoft.VisualStudio.TestTools.UnitTesting;
using CMS.CMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS.DAL.Entities.Tests
{
    [TestClass()]
    public class UserTests
    {
        private User _user;

        [TestInitialize]
        public void TestInitialize()
        {
            _user = new User
            {
                Name = "User",
                PersonalWebpage = "www.userpage.com"
            };
        }

        [TestMethod()]
        public void getNameTest()
        {
            if(_user.getName() != "User")
                Assert.Fail();
        }

        [TestMethod()]
        public void setNameTest()
        {
            _user.setName("U");
            if(_user.Name != "U")
                Assert.Fail();
        }

        [TestMethod()]
        public void getPersonalWebPageTest()
        {
            if(_user.getPersonalWebPage() != "www.userpage.com")
                Assert.Fail();
        }

        [TestMethod()]
        public void setPersonalWebPageTest()
        {
            _user.setPersonalWebPage("");
            if(_user.PersonalWebpage != "")
                Assert.Fail();
        }
    }
}
