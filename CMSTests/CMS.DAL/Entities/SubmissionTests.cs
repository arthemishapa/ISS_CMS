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
    public class SubmissionTests
    {
        private Submission _submission;

        [TestInitialize]
        public void TestInitialize()
        {
            _submission = new Submission
            {
                Id = 1,
                ConferenceId = 2,
                AuthorId = "AuthorId",
                Filename = "Filename.txt",
                Title = "Title",
                Abstract = "Abstract.abs"
            };
        }
        [TestMethod()]
        public void getIdTest()
        {
            if(_submission.getId() != 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void setIdTest()
        {
            _submission.setId(2);
            if(_submission.Id != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void getConferenceIdTest()
        {
            if(_submission.getConferenceId() != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void setConferenceIdTest()
        {
            _submission.setConferenceId(3);
            if(_submission.ConferenceId != 3)
                Assert.Fail();
        }

        [TestMethod()]
        public void getAuthorIdTest()
        {
            if(_submission.getAuthorId() != "AuthorId")
                 Assert.Fail();
        }

        [TestMethod()]
        public void setAuthorIdTest()
        {
            _submission.setAuthorId("authid");
            if(_submission.AuthorId != "authid")
                Assert.Fail();
        }

        [TestMethod()]
        public void getTitleTest()
        {
            if(_submission.getTitle() != "Title")
                Assert.Fail();
        }

        [TestMethod()]
        public void setTitleTest()
        {
            _submission.setTitle("titel");
            if(_submission.Title != "titel")
                Assert.Fail();
        }

        [TestMethod()]
        public void getAbstractTest()
        {
            if(_submission.getAbstract() != "Abstract.abs")
                Assert.Fail();
        }

        [TestMethod()]
        public void setAbstractTest()
        {
            _submission.setAbstract("abs");
            if(_submission.Abstract != "abs")
                Assert.Fail();
        }

        [TestMethod()]
        public void getFileNameTest()
        {
            if(_submission.getFileName() != "Filename.txt")
            Assert.Fail();
        }

        [TestMethod()]
        public void setFileNameTest()
        {
            _submission.setFileName("file.txt");
            if(_submission.Filename != "file.txt")
                Assert.Fail();
        }
    }
}