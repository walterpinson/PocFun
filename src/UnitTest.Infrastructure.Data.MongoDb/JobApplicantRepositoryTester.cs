using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
