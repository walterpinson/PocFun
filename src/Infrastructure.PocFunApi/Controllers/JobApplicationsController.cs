using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Application.Messages;
using Core.Application.Services;
using Core.Domain.Models;
using Microsoft.Practices.Unity;

namespace Infrastructure.PocFunApi.Controllers
{
    public class JobApplicationsController : ApiController
    {
        private readonly IRecruiter _recruiter;

        public JobApplicationsController([Dependency("mongo")] IRecruiter mongoRecruiter)
        {
            _recruiter = mongoRecruiter;
        }

        // GET api/jobapplication
        public IList<JobApplication> Get()
        {
            return null;
        }

        // GET api/jobapplication/5
        public IList<JobApplicationDto> Get(Guid jobId)
        {
            return _recruiter.GetApplications(jobId);
        }

        // POST api/jobapplication
        public JobApplicationDto Post(JobDto job, JobApplicantDto applicant)
        {
            return _recruiter.Apply(job, applicant);
        }

        // PUT api/jobapplication/5
        public JobApplicationDto Put(Guid id, JobApplicationDto jobApplication)
        {
            return null;
        }

        // DELETE api/jobapplication/5
        public void Delete(Guid id)
        {
        }
    }
}
