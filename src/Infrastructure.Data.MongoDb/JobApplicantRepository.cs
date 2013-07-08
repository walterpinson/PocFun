using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb.Models;
using MongoDB.Driver;
using MongoRepository;
using AutoMapper;

namespace Infrastructure.Data.MongoDb
{
    public class JobApplicantRepository : MongoRepository<MongoJobApplicant>, IJobApplicantRepository
    {
        /*
         * This class will make extensive use of AutoMapper.  MongoRepository requires models to inherit from
         * IEntity; which decorates the Id field with attributes.  We must not pollute our domain model, so 
         * we will map between our Core.Models and MangoDb.Models.
         */

        public JobApplicantRepository(string connectionString) : this(new MongoUrl(connectionString))
        {
        }

        public JobApplicantRepository(MongoUrl url) : base(url)
        {
        }

        public JobApplicant Get(Guid id)
        {
            return Mapper.Map<JobApplicant>(GetById(id));
        }

        public JobApplicant Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JobApplicant> GetAll()
        {
            IList<MongoJobApplicant> mongoJobApplicantList
                = this.Where(u => u.Id != Guid.Empty).ToList();
            var jobApplicantList = Mapper.Map<IList<MongoJobApplicant>, IList<JobApplicant>>(mongoJobApplicantList);
            return jobApplicantList.AsQueryable();
        }

        public JobApplicant Create(JobApplicant entity)
        {
            var mongoEntity = Mapper.Map<MongoJobApplicant>(entity);
            var returned = Add(mongoEntity);
            entity = Mapper.Map<JobApplicant>(returned);
            return entity;
        }

        public JobApplicant Update(JobApplicant entity)
        {
            var mongoEntity = Mapper.Map<MongoJobApplicant>(entity);
            var returned = base.Update(mongoEntity);
            entity = Mapper.Map<JobApplicant>(returned);
            return entity;
        }

        public void Delete(JobApplicant entity)
        {
            Delete(entity.Id);
        }
    }
}
