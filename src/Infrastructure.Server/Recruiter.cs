using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Application.Messages;
using Core.Application.Services;
using AutoMapper;

namespace Infrastructure.Server
{
    public class Recruiter : IRecruiter
    {
        private readonly IApplyForJobsService _applyForJobsService;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobRepository _jobRepository;

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
            var applicants = job.GetApplicants();

            return Mapper.Map<IList<JobApplicant>,IList<JobApplicantDto>>(applicants);
        }

        public IList<JobApplicationDto> GetApplications(Guid jobId)
        {
            var job = _jobRepository.Get(jobId);
            var applications = job.Applications;

            IList<JobApplication> appList = applications.ToList();

            return Mapper.Map<IList<JobApplication>, IList<JobApplicationDto>>(appList);
        }

        public JobApplicationDto Apply(JobDto job, JobApplicantDto applicant)
        {
            var mappedJob = Mapper.Map<Job>(job);
            var mappedApplicant = Mapper.Map<JobApplicant>(applicant);

            var application = _applyForJobsService.SubmitApplication(mappedApplicant, mappedJob);

            return Mapper.Map<JobApplicationDto>(application);
        }

        public void Hire(JobDto job, JobApplicantDto applicant)
        {
            throw new NotImplementedException();
        }
    }
}
