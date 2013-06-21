using MongoRepository;
using MongoDB.Bson.Serialization.Attributes;
using Core.Domain.Models;

namespace Infrastructure.Data.MongoDb.Models
{
    public class MongoJobApplicant : IJobApplicant, IEntity
    {
        [BsonId]
        public string Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
