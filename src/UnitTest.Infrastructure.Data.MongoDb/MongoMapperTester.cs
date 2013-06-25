using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.MongoDb;
using AutoMapper;
using NUnit.Framework;

namespace UnitTest.Infrastructure.Data.MongoDb
{
    [TestFixture]
    public class MongoMapperTester
    {
        [Test]
        public void CanConfigureAutoMapperforMongo()
        {
            MongoMapper.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
