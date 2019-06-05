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
    public class SectionTests
    {

        private Section _section;

        [TestInitialize]
        public void TestInitialize()
        {
            _section = new Section { Id = 1, Name = "S1",  SessionId = 2, Session  = new Session() };
        }
        [TestMethod()]
        public void getIdTest()
        {
            if(_section.getId() != 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void setIdTest()
        {
            _section.setId(2);
            if(_section.Id != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void getSessionIdTest()
        {
            if(_section.getSessionId() != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void setSessionIdTest()
        {
            _section.setSessionId(3);
            if(_section.SessionId != 3)
                Assert.Fail();
        }

        [TestMethod()]
        public void getNameTest()
        {
            if(_section.getName() != "S1")
                Assert.Fail();
        }

        [TestMethod()]
        public void setNameTest()
        {
            _section.setName("S2");
            if(_section.Name != "S2")
                Assert.Fail();
        }
    }
}