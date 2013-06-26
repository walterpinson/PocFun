using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;
using Core.Application.Messages;
using Core.Application.Services;

namespace Infrastructure.Server
{
    public class Recruiter
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
    }
}
