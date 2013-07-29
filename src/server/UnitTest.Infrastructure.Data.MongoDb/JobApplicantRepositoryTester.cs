using System;
using System.Configuration;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb;
using NUnit.Framework;
using MongoDB.Driver;

namespace UnitTest.Infrastructure.Data.MongoDb
{
    [TestFixture]
    public class JobApplicantRepositoryTester
    {
        private JobApplicant _jobApplicant;
        private IJobApplicantRepository _subjectUnderTest;
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
            _subjectUnderTest = new JobApplicantRepository(_mongoUrl);
        }

        [TearDown]
        public void Cleanup()
        {
            DropDb();
            _jobApplicant = null;
            _subjectUnderTest = null;
        }

        [Test]
        public void CanAddJobApplicant()
        {
            // ARRANGE
            _jobApplicant = ConstructJobApplicant();

            // ACT
            var added = _subjectUnderTest.Create(_jobApplicant);

            // ASSERT
            Assert.That(added, Is.Not.Null);
            Assert.That(added.Id, Is.Not.Null);
            Assert.That(added.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void CanGetJobApplicant()
        {
            // ARRANGE
            _jobApplicant = ConstructJobApplicant();
            var created = _subjectUnderTest.Create(_jobApplicant);

            // ACT
            var retrieved = _subjectUnderTest.Get(created.Id);

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved.Id, Is.EqualTo(created.Id));
        }

        [Test]
        public void CanGetAllJobApplicants()
        {
            // ARRANGE
            _jobApplicant = ConstructJobApplicant();
            var job2 = ConstructJobApplicant();
            var created1 = _subjectUnderTest.Create(_jobApplicant);
            var created2 = _subjectUnderTest.Create(job2);


            // ACT
            IQueryable<JobApplicant> retrieved = _subjectUnderTest.GetAll();
            var retrieved1 = retrieved.Where(j => j.Id == created1.Id);
            var retrieved2 = retrieved.Where(j => j.Id == created2.Id);

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved1, Is.Not.Null);
            Assert.That(retrieved2, Is.Not.Null);
        }

        [Test]
        public void CanUpdateJobApplicant()
        {
            // ARRANGE
            _jobApplicant = ConstructJobApplicant();
            var created = _subjectUnderTest.Create(_jobApplicant);
            var retrieved = _subjectUnderTest.Get(created.Id);
            var newName = new Name { First = "NEW", Last = "NewLast" };
            retrieved.Name = newName;


            // ACT
            var updated = _subjectUnderTest.Update(retrieved);

            // ASSERT
            Assert.That(updated, Is.Not.Null);
            Assert.That(updated.Id, Is.EqualTo(created.Id));
            Assert.That(updated.Name, Is.EqualTo(newName));
        }

        [Test]
        public void CanDeleteJobApplicant()
        {
            // ARRANGE
            _jobApplicant = ConstructJobApplicant();
            var created = _subjectUnderTest.Create(_jobApplicant);

            // ACT
            _subjectUnderTest.Delete(created);
            var retrieved = _subjectUnderTest.Get(created.Id);

            // ASSERT
            Assert.That(created.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(retrieved, Is.Null);
        }

        private void DropDb()
        {
            var client = new MongoClient(_mongoUrl);
            client.GetServer().DropDatabase(_mongoUrl.DatabaseName);
        }

        private JobApplicant ConstructJobApplicant()
        {
            var name = new Name {First = "John", Last = "Doe"};
            var address = new Address
                {
                    Street = "21 Jump Street",
                    City = "Your City",
                    State = "NJ",
                    Zip = "00123"
                };

            var jobApplicant = new JobApplicant
                {
                    Name = name,
                    Address = address,
                    PhoneNumber = "222-111-1234"
                };


            return jobApplicant;
        }
    }
}
