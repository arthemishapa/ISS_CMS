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
    public class ConferenceTests
    {
        private Conference _conference;
        [TestInitialize]
        public void TestInitialize()
        {
            _conference = new Conference
            {
                Id = 1,
                Name = "C1",
                ChairId = "3",
                StartDate = DateTime.Now
            };
        }
        [TestMethod()]
        public void getIdTest()
        {
            if(_conference.getId() != 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void setIdTest()
        {
            _conference.setId(2);
            if(_conference.Id != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void getNameTest()
        {
            if (_conference.getName() != "C1") 
                Assert.Fail();
        }

        [TestMethod()]
        public void setNameTest()
        {
            _conference.setName("C2");
            if(_conference.Name != "C2")
               Assert.Fail();
        }

        [TestMethod()]
        public void getChairIdTest()
        {
            if(_conference.getChairId() != "3")
               Assert.Fail();
        }

        [TestMethod()]
        public void setChairIdTest()
        {
            _conference.setChairId("4");
            if(_conference.ChairId != "4")
             Assert.Fail();
        }

        [TestMethod()]
        public void getStartDateTest()
        {
            if(_conference.getStartDate() != DateTime.Now)
                Assert.Fail();
        }

        [TestMethod()]
        public void setStartDateTest()
        {
            _conference.setStartDate(DateTime.Now.AddDays(1));
            if(_conference.StartDate != DateTime.Now.AddDays(1))
              Assert.Fail();
        }
    }
}