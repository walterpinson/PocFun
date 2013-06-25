using System;
using System.Configuration;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb;
using NUnit.Framework;
using MongoDB.Driver;

namespace UnitTest.Infrastructure.Data.MongoDb
{
    [TestFixture]
    public class JobRepositoryTester
    {
        private Job _job;
        private IJobRepository _subjectUnderTest;
        private MongoUrl _mongoUrl;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            MongoMapper.Configure();

            _mongoUrl = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            DropDb();
        }

        [SetUp]
        public void Setup()
        {
            _subjectUnderTest = new JobRepository(_mongoUrl);
        }

        [TearDown]
        public void Cleanup()
        {
            DropDb();
            _job = null;
            _subjectUnderTest = null;
        }

        private void DropDb()
        {
            var client = new MongoClient(_mongoUrl);
            client.GetServer().DropDatabase(_mongoUrl.DatabaseName);
        }

        [Test]
        public void CanAddJob()
        {
            // ARRANGE
            _job = ConstructJob();

            // ACT
            var added = _subjectUnderTest.Create(_job);

            // ASSERT
            Assert.That(added, Is.Not.Null);
            Assert.That(added.Id, Is.Not.Null);
        }

        public void CanGetJob()
        {
            // ARRANGE
            _job = ConstructJob();
            _subjectUnderTest.Create(_job);

            // ACT
            var retrieved = _subjectUnderTest.Get(_job.Id);

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved.Id, Is.EqualTo(_job.Id));
        }

        public void CanGetAllJobs()
        {
            // ARRANGE
            _job = ConstructJob();
            var job2 = ConstructJob();
            _subjectUnderTest.Create(_job);
            _subjectUnderTest.Create(job2);

            // ACT
            var retrieved = _subjectUnderTest.GetAll();

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
        }

        [Test]
        public void CanDeleteJob()
        {
            // ARRANGE
            _job = ConstructJob();
            _subjectUnderTest.Create(_job);
            var jobId = _job.Id;

            // ACT
            _subjectUnderTest.Delete(_job);
            var retrieved = _subjectUnderTest.Get(jobId);

            // ASSERT
            Assert.That(jobId, Is.Not.EqualTo(Guid.Empty));
            Assert.That(retrieved, Is.Null);
        }

        private Job ConstructJob()
        {
            var job = new Job
            {
                Title = "Chief Happy Officer",
                IsFilled = false,
                Salary = 395000m,
                Applicants = null,
                PersonHired = null
            };

            return job;
        }
    }
}
