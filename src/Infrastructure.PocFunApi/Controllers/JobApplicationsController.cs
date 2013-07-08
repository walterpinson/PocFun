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

        // GET api/jobapplications
        [HttpGet]
        public IList<JobApplication> Get()
        {
            return null;
        }

        // GET api/jobapplications/0000-...
        [HttpGet]
        public IList<JobApplicationDto> Get(Guid jobId)
        {
            return _recruiter.GetApplications(jobId);
        }

        // POST api/jobapplications
        [HttpPost]
        public JobApplicationDto Post(ApplicationRequest application)
        {
            return _recruiter.Apply(application.JobId, application.ApplicantId);
        }


        // PUT api/jobapplications/5
        [HttpPut]
        public JobApplicationDto Put(Guid id, JobApplicationDto jobApplication)
        {
            return null;
        }

        // DELETE api/jobapplications/5
        public void Delete(Guid id)
        {
        }
    }
}
