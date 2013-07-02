using Core.Domain.Models;

namespace Core.Domain.Services
{
    public interface IApplyForJobsService
    {
        IJobApplication SubmitApplication(JobApplicant applicant, IJob job);
    }
}
