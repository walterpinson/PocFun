using System;

namespace Core.Domain.Models
{
    public class JobApplication : IJobApplication
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid JobApplicantId { get; set; }
        public Guid JobId { get; set; }

        public JobApplication()
        {
            Date = DateTime.Now;
        }
    }
}
