using System;
using System.Collections.Generic;
using System.Linq;
using Core.Application.Messages;
using Core.Application.Services;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Server;
using NUnit.Framework;
using NSubstitute;
using AutoMapper;

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
            var job = Substitute.For<JobDto>();
            var applicant = Substitute.For<JobApplicantDto>();
            var jobId = job.Id = Guid.NewGuid();
            var applicantId = applicant.Id = Guid.NewGuid();

            var application = Substitute.For<JobApplication>();
            application.ApplicantId = applicantId;
            application.PositionId = jobId;
            application.Applicant = Mapper.Map<JobApplicant>(applicant);
            application.Position = Mapper.Map<Job>(job);

            _applyForJobsService.SubmitApplication(application.Applicant, application.Position).ReturnsForAnyArgs(application);

            // ACT
            var returnedApplication = _subjectUnderTest.Apply(job, applicant);

            // ASSERT
            Assert.That(returnedApplication, Is.Not.Null);
            Assert.That(returnedApplication.Position.Id, Is.EqualTo(jobId));
            Assert.That(returnedApplication.Applicant.Id, Is.EqualTo(applicantId));
            _applyForJobsService.ReceivedWithAnyArgs(1).SubmitApplication(application.Applicant, application.Position);
        }

        [Test]
        public void CanHire()
        {
            // ARRANGE
            var job = Substitute.For<JobDto>();
            var applicant = Substitute.For<JobApplicantDto>();
            applicant.Id = Guid.NewGuid();

            var job2Return = Mapper.Map<Job>(job);
            var applicant2Return = Mapper.Map<JobApplicant>(applicant);
            job2Return.Fill(applicant2Return);
            job2Return.PersonHiredId = job2Return.PersonHired.Id;


            _jobRepository.Update(job2Return).ReturnsForAnyArgs(job2Return);

            // ACT
            var returnedJob = _subjectUnderTest.Hire(job, applicant);


            // ASSERT
            Assert.That(returnedJob, Is.Not.Null);
            Assert.That(returnedJob.IsFilled, Is.True);
            Assert.That(returnedJob.PersonHiredId, Is.Not.Null);
            Assert.That(returnedJob.PersonHiredId, Is.Not.EqualTo(Guid.Empty));
            Assert.That(returnedJob.PersonHiredId, Is.EqualTo(applicant.Id));
            _jobRepository.ReceivedWithAnyArgs(1).Update(job2Return);
        }
    }
}
