using System;

namespace Core.Domain.Models
{
    public class JobApplicant
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
