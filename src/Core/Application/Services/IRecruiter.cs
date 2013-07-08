using System;
using System.Collections.Generic;
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

        JobDto AddNewJob(JobDto job);
        JobApplicantDto AddNewApplicant(JobApplicantDto jobApplicant);

        JobApplicationDto Apply(JobDto job, JobApplicantDto applicant);
        JobApplicationDto Apply(Guid jobId, Guid applicantId);
        JobDto Hire(JobDto job, JobApplicantDto applicant);
    }
}
