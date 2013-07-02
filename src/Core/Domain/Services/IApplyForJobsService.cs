using Core.Domain.Models;

namespace Core.Domain.Services
{
    public interface IApplyForJobsService
    {
        void SubmitApplication(JobApplicant applicant, IJob job);
    }
}
