using System;
using System.Collections.Generic;
using System.Linq;
using Core.Application.Services;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Server;
using NUnit.Framework;
using NSubstitute;

namespace UnitTest.Infrastructure.Server
{
    [TestFixture]
    public class RecruiterTester
    {
        private IRecruiter _subjectUnderTest;
        private IJobApplicantRepository _jobApplicantRepository;
        private IJobRepository _jobRepository;
        private IApplyForJobsService _applyForJobsService;

        
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            DtoMapper.Configure();

            _applyForJobsService = Substitute.For<IApplyForJobsService>();
            _jobApplicantRepository = Substitute.For<IJobApplicantRepository>();
            _jobRepository = Substitute.For<IJobRepository>();

            _subjectUnderTest = new Recruiter(_applyForJobsService, _jobRepository, _jobApplicantRepository);
        }

        [SetUp]
        public void Setup()
        {
            _applyForJobsService.ClearReceivedCalls();
            _jobRepository.ClearReceivedCalls();
            _jobApplicantRepository.ClearReceivedCalls();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            _applyForJobsService = null;
            _jobApplicantRepository = null;
            _jobRepository = null;

            _subjectUnderTest = null;
        }

        [Test]
        public void CanGetJob()
        {
            // ARRANGE
            var returnedJob = Substitute.For<Job>();
            _jobRepository.Get(Guid.Empty).ReturnsForAnyArgs(returnedJob);

            // ACT
            var job = _subjectUnderTest.GetJob(Guid.Empty);

            // ASSERT
            Assert.That(job, Is.Not.Null);
            _jobRepository.ReceivedWithAnyArgs(1).Get(Guid.Empty);
        }

        [Test]
        public void CanGetJobs()
        {
            // ARRANGE
            var returnedJobs = Substitute.For<IQueryable<Job>>();
            _jobRepository.GetAll().ReturnsForAnyArgs(returnedJobs);

            // ACT
            var jobs = _subjectUnderTest.GetJobs();

            // ASSERT
            Assert.That(jobs, Is.Not.Null);
            Assert.That(jobs.Count, Is.EqualTo(0));
            _jobRepository.ReceivedWithAnyArgs(1).GetAll();
        }

        [Test]
        public void CanGetApplicants()
        {
            // ARRANGE
            var returnedApplicants = Substitute.For<IQueryable<JobApplicant>>();
            _jobApplicantRepository.GetAll().ReturnsForAnyArgs(returnedApplicants);

            // ACT
            var jobApplicants = _subjectUnderTest.GetApplicants();

            // ASSERT
            Assert.That(jobApplicants, Is.Not.Null);
            Assert.That(jobApplicants.Count, Is.EqualTo(0));
            _jobApplicantRepository.ReceivedWithAnyArgs(1).GetAll();
        }

        [Test]
        public void CanGetApplicantsPerJob()
        {
            // ARRANGE
            var applications = Substitute.For<IList<JobApplication>>();
            var job = Substitute.For<Job>();
            job.Applications = applications;
            _jobRepository.Get(Guid.Empty).ReturnsForAnyArgs(job);

            // ACT
            var applicants = _subjectUnderTest.GetApplicants(Guid.Empty);

            // ASSERT
            Assert.That(applicants, Is.Not.Null);
            Assert.That(applicants.Count, Is.EqualTo(0));
            _jobRepository.ReceivedWithAnyArgs(1).Get(Guid.Empty);
        }

        [Test]
        public void CanGetApplications()
        {
            // ARRANGE
            var applications = Substitute.For<IList<JobApplication>>();
            var job = Substitute.For<Job>();
            job.Applications = applications;
            _jobRepository.Get(Guid.Empty).ReturnsForAnyArgs(job);

            // ACT
            var returnedApplications = _subjectUnderTest.GetApplications(Guid.Empty);

            // ASSERT
            Assert.That(returnedApplications, Is.Not.Null);
            Assert.That(returnedApplications.Count, Is.EqualTo(0));
            _jobRepository.ReceivedWithAnyArgs(1).Get(Guid.Empty);
        }

        [Test]
        public void CanApply()
        {
            // ARRANGE

            // ACT

            // ASSERT
        }

        [Test]
        public void CanHire()
        {
            // ARRANGE

            // ACT

            // ASSERT
        }
    }
}
