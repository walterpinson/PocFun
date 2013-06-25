using System;
using MongoRepository;
using MongoDB.Bson.Serialization.Attributes;
using Core.Domain.Models;

namespace Infrastructure.Data.MongoDb.Models
{
    public class MongoJobApplicant : JobApplicant, IEntity {}
}
