using System;
namespace Core.Domain.Models
{
    public interface IJobApplicant
    {
        string Id { get; set; }
        Address Address { get; set; }
        Name Name { get; set; }
        string PhoneNumber { get; set; }
    }
}
