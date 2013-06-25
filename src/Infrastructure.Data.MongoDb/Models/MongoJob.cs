using System;
using Core.Domain.Models;
using MongoRepository;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Data.MongoDb.Models
{
    public class MongoJob : Job, IEntity
    {
        [BsonId]
        //public Guid Id { get; set; }
        public new Guid Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }
}
