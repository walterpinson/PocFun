using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Messages;

namespace Core.Application.Services
{
    public interface IRecruiter
    {
        JobDto GetJob(Guid jobId);
        IList<JobDto> GetJobs();
        IList<JobApplicantDto> GetApplicants();
        IList<JobApplicantDto> GetApplicants(Guid jobId);
        IList<JobApplicationDto> GetApplications(Guid jobId);

        void Apply(JobDto job, JobApplicantDto applicant);
        void Hire(JobDto job, JobApplicantDto applicant);
    }
}
