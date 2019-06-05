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
    public class RequestTests
    {
        private Request _request;

        [TestInitialize]
        public void TestInitialize()
        {
            _request = new Request {
                Id = 1,
                UserRequesterId = "2",
                ConferenceId = 3,
                LocationId = 4,
            };
        }
        [TestMethod()]
        public void getIdTest()
        {
            if(_request.getId() != 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void setIdTest()
        {
            _request.setId(2);
            if(_request.Id != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void getUserRequesterIdTest()
        {
            if(_request.getUserRequesterId() != "2")
                Assert.Fail();
        }

        [TestMethod()]
        public void setUserRequesterIdTest()
        {
            _request.setUserRequesterId("3");
            if(_request.UserRequesterId != "3")
                Assert.Fail();
        }

        [TestMethod()]
        public void getConferenceIdTest()
        {
            if(_request.getConferenceId() != 3)
                Assert.Fail();
        }

        [TestMethod()]
        public void setConferenceIdTest()
        {
            _request.setConferenceId(4);
            if(_request.ConferenceId != 4)
                Assert.Fail();
        }

        [TestMethod()]
        public void getLocationIdTest()
        {
            if(_request.getLocationId() != 4)
                Assert.Fail();
        }

        [TestMethod()]
        public void setLocationIdTest()
        {
            _request.setLocationId(5);
            if(_request.LocationId != 5)
                Assert.Fail();
        }
    }
}