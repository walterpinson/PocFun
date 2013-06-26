using NUnit.Framework;
using Core.Domain.Models;
using NSubstitute;

namespace UnitTest.Core.Domain.Models
{
    [TestFixture]
    public class JobTester
    {
        private Job _subjectUnderTest;

        [TearDown]
        private void TearDown()
        {
            _subjectUnderTest = null;
        }

        [Test]
        public void CanConstructJobWithDefaultConstructor() {
            // ARRANGE

            // ACT
            _subjectUnderTest = new Job();

            // ASSERT
            Assert.That(_subjectUnderTest, Is.Not.Null);
            Assert.That(_subjectUnderTest.IsFilled, Is.False);
        }

        [Test]
        public void CanFillTheJob()
        {
            // ARRANGE
            var candidate = Substitute.For<JobApplicant>();
            candidate.Id = System.Guid.NewGuid();
            _subjectUnderTest = new Job();

            // ACT
            _subjectUnderTest.Fill(candidate);

            // ASSERT
            Assert.That(_subjectUnderTest.IsFilled, Is.True);
            Assert.That(_subjectUnderTest.PersonHired, Is.EqualTo(candidate));
        }

        [Test]
        public void CanAcceptApplication()
        {
            // ARRANGE
            var application = Substitute.For<JobApplication>();
            application.Id = System.Guid.NewGuid();
            _subjectUnderTest = new Job();

            // ACT
            _subjectUnderTest.AcceptApplication(application);

            // ASSERT
            Assert.That(_subjectUnderTest.Applications, Is.Not.Null);
            Assert.That(_subjectUnderTest.Applications.Count, Is.EqualTo(1));
            Assert.That(_subjectUnderTest.Applications[0], Is.EqualTo(application));
        }
    }
}
