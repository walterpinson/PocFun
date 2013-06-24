using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.SqlAzure;
using NUnit.Framework;

namespace UnitTest.Infrastructure.Data.SqlAzure
{
    [TestFixture]
    public class JobRepositoryTester
    {
        private Job _job;
        private IJobRepository _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            _subjectUnderTest = new JobRepository();
        }

        [TearDown]
        public void TearDown()
        {
            _job = null;
            _subjectUnderTest = null;
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
