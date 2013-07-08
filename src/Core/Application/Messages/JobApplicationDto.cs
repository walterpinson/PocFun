using System;

namespace Core.Application.Messages
{
    public class JobApplicationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid JobId { get; set; }
        public Guid JobApplicantId { get; set; }
    }
}
