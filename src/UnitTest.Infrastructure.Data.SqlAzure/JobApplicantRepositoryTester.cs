using System;
using NUnit.Framework;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.SqlAzure;

namespace UnitTest.Infrastructure.Data.SqlAzure
{
    [TestFixture]
    public class JobApplicantRepositoryTester
    {
        private JobApplicant _applicant;
        private IJobApplicantRepository _subjectUnderTest;

        [SetUp]
        public void Setup()
        {
            _subjectUnderTest = new JobApplicantRepository();
        }

        [TearDown]
        public void TearDown()
        {
            _applicant = null;
            _subjectUnderTest = null;
        }

        [Test]
        public void CanAddJobApplicant()
        {
            // ARRANGE
            _applicant = ConstructJobApplicant();

            // ACT
            var added = _subjectUnderTest.Create(_applicant);

            // ASSERT
            Assert.That(added, Is.Not.Null);
            Assert.That(added.Id, Is.Not.Null);
        }

        [Test]
        public void CanGetJobApplicant()
        {
            // ARRANGE
            var added = _subjectUnderTest.Create(ConstructJobApplicant());

            // ACT
            var retrieved = _subjectUnderTest.Get(added.Id);

            // ASSERT
            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved.Id, Is.EqualTo(added.Id));
        }

        [Test]
        public void CanUpdateJobApplicant()
        {
            // ARRANGE
            var updatedPhoneNumber = "999-999-9999";
            _applicant = ConstructJobApplicant();
            _subjectUnderTest.Create(_applicant);
            _applicant.PhoneNumber = updatedPhoneNumber;

            // ACT
            var updated = _subjectUnderTest.Create(_applicant);

            // ASSERT
            Assert.That(updated, Is.Not.Null);
            Assert.That(updated.PhoneNumber, Is.EqualTo(updatedPhoneNumber));
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void CanDeleteJobApplicant()
        {
            // ARRANGE
            _applicant = ConstructJobApplicant();
            var added = _subjectUnderTest.Create(_applicant);

            // ACT
            _subjectUnderTest.Delete(added);
            _subjectUnderTest.Get(_applicant.Id);

            // ASSERT
            // An exception should be thrown
        }

        private JobApplicant ConstructJobApplicant()
        {
            var random = new Random();
            var index = random.Next(1000, 9999).ToString();
            var name = new Name { First = "John", Last = "Doe" + index };
            var address = new Address
            {
                Street = "21 Jump Street",
                City = "Hollywood",
                State = "CA",
                Zip = "90210"
            };

            var applicant = new JobApplicant
            {
                Name = name,
                Address = address,
                PhoneNumber = "222-812-8123"
            };

            return applicant;
        }
    }
}
