using System;

namespace Core.Domain.Models
{
    public class Job
    {
        public long Id { get; set; }
        public Guid IdBig { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
    }
}
