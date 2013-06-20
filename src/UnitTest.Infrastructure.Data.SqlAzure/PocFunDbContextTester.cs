using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Infrastructure.Data.SqlAzure;

namespace UnitTest.Infrastructure.Data.SqlAzure
{
    [TestFixture]
    public class PocFunDbContextTester
    {
        private PocFunDbContext _context;

        [TestFixtureSetUp]
        private void TestFixtureSetup()
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
