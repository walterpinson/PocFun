using NUnit.Framework;
using Infrastructure.Data.SqlAzure;

namespace UnitTest.Infrastructure.Data.SqlAzure
{
    [TestFixture]
    public class PocFunDbContextTester
    {
        private PocFunDbContext _context;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
        }

        [Test]
        public void CanCreateDatabase()
        {
            // ARRANGE
            _context = EfProvider.GetContext();

            // ACT
            _context.Database.Initialize(true);

            // ASSERT
            Assert.NotNull(_context.Database.Connection);
        }
    }
}
