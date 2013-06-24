using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb;
using NUnit.Framework;
using NSubstitute;
using MongoRepository;
using MongoDB.Driver;

namespace UnitTest.Infrastructure.Data.MongoDb
{
    [TestFixture]
    public class JobRepositoryTester
    {
        private Job _job;
        private IJobRepository _subjectUnderTest;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            this.DropDB();
        }

        [SetUp]
        public void Setup()
        {
            _subjectUnderTest = new JobRepository();
        }

        [TearDown]
        public void Cleanup()
        {
            this.DropDB();
            _job = null;
            _subjectUnderTest = null;
        }

        private void DropDB()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
            var client = new MongoClient(url);
            client.GetServer().DropDatabase(url.DatabaseName);
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
