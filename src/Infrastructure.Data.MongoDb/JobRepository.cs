using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb.Models;
using MongoRepository;

namespace Infrastructure.Data.MongoDb
{
    public class JobRepository : MongoRepository<MongoJob>, IJobRepository
    {
        public Job Get(Guid id)
        {
            return GetById(id) as Job;
        }

        public Job Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Job> GetAll()
        {
            return this as IQueryable<Job>;
        }

        public Job Create(Job entity)
        {
            return base.Add(entity as MongoJob);
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
