using System;

namespace Infrastructure.PocFunApi.Models
{
    public class ApplicationRequest
    {
        public Guid JobId { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
