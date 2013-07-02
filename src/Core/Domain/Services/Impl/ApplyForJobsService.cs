using System;
using Core.Domain.Models;

namespace Core.Domain.Services.Impl
{
    public class ApplyForJobsService : IApplyForJobsService
    {
        public void SubmitApplication(JobApplicant applicant, IJob job)
        {
            if (null == applicant || null == job)
                throw new Exception();

            var application = new JobApplication
            {
                Applicant = applicant,
                Date = DateTime.Now
            };

            job.AcceptApplication(application);
        }
    }
}
