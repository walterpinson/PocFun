﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Infrastructure.Data.MongoDb.Models;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepository;

namespace Infrastructure.Data.MongoDb
{
    public class JobRepository : MongoRepository<MongoJob>, IJobRepository
    {
        public JobRepository(string connectionString) :this(new MongoUrl(connectionString)){}
        public JobRepository(MongoUrl url) : base(url)
        {
            MongoMapper.Configure();
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
            IList<MongoJob> mongoJobList
                = this.Where(u => u.Id != Guid.Empty).ToList();
            var jobList = Mapper.Map<IList<MongoJob>, IList<Job>>(mongoJobList);
            return jobList.AsQueryable();
        }

        public Job Create(Job entity)
        {
            var mongoEntity = Mapper.Map<MongoJob>(entity);
            var returned = Add(mongoEntity);
            entity = Mapper.Map<Job>(returned);
            return entity;
        }

        public Job Update(Job entity)
        {
            var mongoEntity = Mapper.Map<MongoJob>(entity);
            var applications = Mapper.Map<IList<JobApplication>, IList<MongoJobApplication>> (entity.Applications);

            foreach(MongoJobApplication app in applications)
            {
                if (Guid.Empty == app.Id)
                {
                    //var oid = new BsonObjectId(new ObjectId());
                    var id = Guid.NewGuid();
                    var bsonId = new BsonBinaryData(id);
                    app.Id = bsonId.AsGuid;
                }
            }

            mongoEntity.Applications =
                Mapper.Map<IList<MongoJobApplication>, IList<JobApplication>>(applications);
;
            var returned =  base.Update(mongoEntity);
            entity = Mapper.Map<Job>(returned);
            return entity;
        }

        public void Delete(Job entity)
        {
            Delete(entity.Id);
        }
    }
}
