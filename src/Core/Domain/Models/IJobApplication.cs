using System;
namespace Core.Domain.Models
{
    public interface IJobApplication
    {
        JobApplicant Applicant { get; set; }
        DateTime Date { get; set; }
        Guid Id { get; set; }
        Job Position { get; set; }
    }
}
