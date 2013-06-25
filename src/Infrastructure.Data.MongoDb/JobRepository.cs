using System;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb.Models;
using AutoMapper;
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
            return Mapper.Map<Job>(GetById(id));
        }

        public Job Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Job> GetAll()
        {
            return Mapper.Map<IQueryable<MongoJob>, IQueryable<Job>>(this);
        }

        public Job Create(Job entity)
        {
            var mongoEntity = Mapper.Map<MongoJob>(entity);
            var returned = Add(mongoEntity);
            return Mapper.Map<Job>(returned);
        }

        public Job Update(Job entity)
        {
            var mongoEntity = Mapper.Map<MongoJob>(entity);
            var returned =  base.Update(mongoEntity);
            return Mapper.Map<Job>(returned);
        }

        public void Delete(Job entity)
        {
            Delete(entity.Id);
        }
    }
}
