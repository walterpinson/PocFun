using System;
namespace Core.Domain.Models
{
    public interface IJobApplication
    {
        DateTime Date { get; set; }
        Guid Id { get; set; }
        Guid JobId { get; set; }
        Guid JobApplicantId { get; set; }
    }
}
