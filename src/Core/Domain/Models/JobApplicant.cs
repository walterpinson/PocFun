namespace Core.Domain.Models
{
    using System;

    public class JobApplicant : IJobApplicant
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
