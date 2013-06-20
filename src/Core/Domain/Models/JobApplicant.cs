using System;

namespace Core.Domain.Models
{
    public class JobApplicant
    {
        public long Id { get; set; }
        public string IdBig { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
    }
}
