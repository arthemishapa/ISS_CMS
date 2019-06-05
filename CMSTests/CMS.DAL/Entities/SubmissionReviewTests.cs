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
    public class SubmissionReviewTests
    {
        private SubmissionReview _submissionReview;

        [TestInitialize]
        public void TestInitialize()
        {
            _submissionReview = new SubmissionReview
            {
                SubmissionId = 1,
                ReviewerId = "2",
                Recommendation = "good"
            };
        }
        [TestMethod()]
        public void getSubmissionIdTest()
        {
            if(_submissionReview.getSubmissionId() != 1)
                Assert.Fail();
        }

        [TestMethod()]
        public void setSubmissionIdTest()
        {
            _submissionReview.setSubmissionId(2);
            if (_submissionReview.SubmissionId != 2)
                Assert.Fail();
        }

        [TestMethod()]
        public void getReviewerIdTest()
        {
            if(_submissionReview.getReviewerId() != "2")
                Assert.Fail();
        }

        [TestMethod()]
        public void setReviewerIdTest()
        {
            _submissionReview.setReviewerId("3");
            if(_submissionReview.ReviewerId != "3")
                Assert.Fail();
        }

        [TestMethod()]
        public void getRecommendationTest()
        {
            if(_submissionReview.getRecommendation() != "good")
                Assert.Fail();
        }

        [TestMethod()]
        public void setRecommendationTest()
        {
            _submissionReview.setRecommendation("none");
            if(_submissionReview.Recommendation != "none")
                Assert.Fail();
        }
    }
}