using System;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb.Models;
using MongoDB.Driver;
using MongoRepository;

namespace Infrastructure.Data.MongoDb
{
    public class JobRepository : MongoRepository<MongoJob>, IJobRepository
    {
        public JobRepository(MongoUrl url) : base(url)
        {
        }

        public Job Get(Guid id)
        {
            return GetById(id);
        }

        public Job Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Job> GetAll()
        {
            return All() as IQueryable<Job>;
        }

        public Job Create(Job entity)
        {
            return Add(entity as MongoJob);
        }

        public Job Update(Job entity)
        {
            return base.Update(entity as MongoJob);
        }

        public void Delete(Job entity)
        {
            base.Delete(entity as MongoJob);
        }
    }
}
