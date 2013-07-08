using AutoMapper;
using Core.Application.Messages;
using Core.Domain.Models;
using Infrastructure.Server;
using NSubstitute;
using NUnit.Framework;

namespace UnitTest.Infrastructure.Server
{
    [TestFixture]
    public class DtoMapperTester
    {
        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            DtoMapper.Configure();            
        }

        [Test]
        public void CanConfigureAutoMapperForDtos()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void CanMapJobDtoToJob()
        {
            // ARRANGE
            var jobDto = Substitute.For<JobDto>();
            var jobDto2 = new JobDto()
                {
                    Title = "Chief Marketing Officer",
                    Salary = 45000m
                };

            // ACT 
            var job = Mapper.Map<Job>(jobDto);
            var job2 = Mapper.Map<Job>(jobDto2);

            // ASSERT
            Assert.That(job, Is.Not.Null);
            Assert.That(job.GetType(), Is.EqualTo(typeof(Job)));
            Assert.That(job2, Is.Not.Null);
            Assert.That(job2.GetType(), Is.EqualTo(typeof(Job)));
        }
    }
}
