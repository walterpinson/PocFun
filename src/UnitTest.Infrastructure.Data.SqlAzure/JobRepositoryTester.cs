using System;
using System.Linq;
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
            Assert.That(added.Id, Is.Not.EqualTo(Guid.Empty));
        }


        [Test]
        public void CanGetJob()
        {
            // ARRANGE
            _job = ConstructJob();
            var created = _subjectUnderTest.Create(_job);

            // ACT
            var retrieved = _subjectUnderTest.Get(created.Id);

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved.Id, Is.EqualTo(created.Id));
        }

        [Test]
        public void CanGetAllJobs()
        {
            // ARRANGE
            _job = ConstructJob();
            var job2 = ConstructJob();
            var created1 = _subjectUnderTest.Create(_job);
            var created2 = _subjectUnderTest.Create(job2);


            // ACT
            IQueryable<Job> retrieved = _subjectUnderTest.GetAll();
            var retrieved1 = retrieved.Where(j => j.Id == created1.Id);
            var retrieved2 = retrieved.Where(j => j.Id == created2.Id);

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved1, Is.Not.Null);
            Assert.That(retrieved2, Is.Not.Null);
        }

        [Test]
        public void CanUpdateJob()
        {
            // ARRANGE
            _job = ConstructJob();
            var created = _subjectUnderTest.Create(_job);
            var retrieved = _subjectUnderTest.Get(created.Id);
            var newTitle = "Better BIGGER New Title";
            retrieved.Title = newTitle;


            // ACT
            var updated = _subjectUnderTest.Update(retrieved);

            // ASSERT
            Assert.That(updated, Is.Not.Null);
            Assert.That(updated.Id, Is.EqualTo(created.Id));
            Assert.That(updated.Title, Is.EqualTo(newTitle));
        }

        [Test]
        public void CanDeleteJob()
        {
            // ARRANGE
            _job = ConstructJob();
            var created = _subjectUnderTest.Create(_job);

            // ACT
            _subjectUnderTest.Delete(created);
            var retrieved = _subjectUnderTest.Get(created.Id);

            // ASSERT
            Assert.That(created.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(retrieved, Is.Null);
        }

        private Job ConstructJob()
        {
            var job = new Job
                {
                    Title = "Chief Happy Officer",
                    IsFilled = false,
                    Salary = 395000m,
                    Applications = null,
                    PersonHired = null
                };

            return job;
        }
    }
}
