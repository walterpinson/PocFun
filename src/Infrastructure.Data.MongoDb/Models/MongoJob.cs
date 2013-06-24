using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
