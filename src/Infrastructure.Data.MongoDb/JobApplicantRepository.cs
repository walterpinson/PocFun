using System;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb.Models;
using MongoRepository;

namespace Infrastructure.Data.MongoDb
{
    public class JobApplicantRepository : MongoRepository<MongoJobApplicant>, IJobApplicantRepository
    {
        /*
         * This class will make extensive use of AutoMapper.  MongoRepository requires models to inherit from
         * IEntity; which decorates the Id field with attributes.  We must not pollute our domain model, so 
         * we will map between our Core.Models and MangoDb.Models.
         */

        public JobApplicant Get(string id)
        {
            throw new NotImplementedException();
        }

        public JobApplicant Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JobApplicant> GetAll()
        {
            throw new NotImplementedException();
        }

        public JobApplicant Create(JobApplicant entity)
        {
            throw new NotImplementedException();
        }

        public JobApplicant Update(JobApplicant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(JobApplicant entity)
        {
            throw new NotImplementedException();
        }
    }
}
