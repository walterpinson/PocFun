using System;
using Core.Domain.Models;

namespace Core.Application.Messages
{
    public class JobApplicantDto
    {
        public Guid Id { get; set; }
        public Address Address { get; set; }
        public Name Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
