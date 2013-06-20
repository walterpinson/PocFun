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
            candidate.Id = System.Guid.NewGuid().ToString();
            _subjectUnderTest = new Job();

            // ACT
            _subjectUnderTest.Fill(candidate);

            // ASSERT
            Assert.That(_subjectUnderTest.IsFilled, Is.True);
            Assert.That(_subjectUnderTest.PersonHired, Is.EqualTo(candidate));
        }
    }
}
