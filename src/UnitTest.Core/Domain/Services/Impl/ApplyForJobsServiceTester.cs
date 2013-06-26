using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Domain.Services.Impl;
using NUnit.Framework;
using NSubstitute;

namespace UnitTest.Core.Domain.Services.Impl
{
    [TestFixture]
    public class ApplyForJobsServiceTester
    {
        private IApplyForJobsService _subjectUnderTest;

        [Test]
        public void CanSubmitJobApplication()
        {
            // ARRANGE
            _subjectUnderTest = new ApplyForJobsService();
            var applicant = Substitute.For<JobApplicant>();
            var job = Substitute.For<Job>();
            job.AcceptApplication(null).ReturnsForAnyArgs(true);

            // ACT
            _subjectUnderTest.SubmitApplication(applicant, job);

            // ASSERT
            job.ReceivedWithAnyArgs(1).AcceptApplication(null);
        }
    }
}
