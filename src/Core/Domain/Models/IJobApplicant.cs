using System;
namespace Core.Domain.Models
{
    public interface IJobApplicant
    {
        Address Address { get; set; }
        string Id { get; set; }
        Name Name { get; set; }
        string PhoneNumber { get; set; }
    }
}
