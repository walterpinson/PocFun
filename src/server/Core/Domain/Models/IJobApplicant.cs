namespace Core.Domain.Models
{
    using System;

    public interface IJobApplicant
    {
        Guid Id { get; set; }
        Address Address { get; set; }
        Name Name { get; set; }
        string PhoneNumber { get; set; }
    }
}
