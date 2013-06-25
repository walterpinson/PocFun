﻿using Core.Domain.Models;
using Infrastructure.Data.MongoDb.Models;
using AutoMapper;

namespace Infrastructure.Data.MongoDb
{
    public static class MongoMapper
    {
        public static void Configure()
        {
            Mapper.CreateMap<Job, MongoJob>();
            Mapper.CreateMap<MongoJob, Job>();
        }
    }
}
