using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;

namespace Core.Domain.Services.Impl
{
    public class ApplyForJobsService : IApplyForJobsService
    {
        public void SubmitApplication(JobApplicant applicant, Job job)
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
