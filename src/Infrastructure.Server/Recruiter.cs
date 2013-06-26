using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Application.Messages;
using Core.Application.Services;
using AutoMapper;

namespace Infrastructure.Server
{
    public class Recruiter : IRecruiter
    {
        private IApplyForJobsService _applyForJobsService;
        private IJobApplicantRepository _jobApplicantRepository;
        private IJobRepository _jobRepository;

        public Recruiter(IApplyForJobsService applyForJobsService, IJobRepository jobRepo, IJobApplicantRepository jobApplicantRepo)
        {
            _applyForJobsService = applyForJobsService;
            _jobApplicantRepository = jobApplicantRepo;
            _jobRepository = jobRepo;
        }

        public JobDto GetJob(Guid jobId)
        {
            var job = _jobRepository.Get(jobId);
            return Mapper.Map<JobDto>(job);
        }

        public IList<JobDto> GetJobs()
        {
            var jobs = _jobRepository.GetAll();
            var jobsList = jobs.ToList();

            return Mapper.Map<IList<Job>, IList<JobDto>>(jobsList);
        }

        public IList<JobApplicantDto> GetApplicants()
        {
            var applicants = _jobApplicantRepository.GetAll();
            var applicantList = applicants.ToList();

            return Mapper.Map<IList<JobApplicant>, IList<JobApplicantDto>>(applicantList);
        }

        public IList<JobApplicantDto> GetApplicants(Guid jobId)
        {
            var job = _jobRepository.Get(jobId);
            var applicants = new List<JobApplicant>();

            foreach (JobApplication app in job.Applications)
            {
                applicants.Add(app.Applicant);
            }

            return Mapper.Map<IList<JobApplicant>,IList<JobApplicantDto>>(applicants);
        }

        public IList<JobApplicationDto> GetApplications(Guid jobId)
        {
            var job = _jobRepository.Get(jobId);
            var applications = job.Applications;

            IList<JobApplication> appList = applications.ToList();

            return Mapper.Map<IList<JobApplication>, IList<JobApplicationDto>>(appList);
        }

        public void Apply(JobDto job, JobApplicantDto applicant)
        {
            throw new NotImplementedException();
        }

        public void Hire(JobDto job, JobApplicantDto applicant)
        {
            throw new NotImplementedException();
        }
    }
}
