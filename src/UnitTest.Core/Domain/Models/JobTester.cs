using NUnit.Framework;
using Core.Domain.Models;

namespace UnitTest.Core.Domain.Models
{
    [TestFixture]
    public class JobTester
    {
        [Test]
        public void CanConstructJobWithDefaultConstructor() {
            // ARRANGE

            // ACT
            var job = new Job();

            // ASSERT
            Assert.That(job, Is.Not.Null);
            Assert.That(job.IsFilled, Is.False);
        }
    }
}
