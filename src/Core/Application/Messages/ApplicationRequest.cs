using System;

namespace Core.Application.Messages
{
    public class ApplicationRequest
    {
        public Guid JobId { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
