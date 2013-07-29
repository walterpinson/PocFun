using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Application.Messages;
using Core.Application.Services;
using Microsoft.Practices.Unity;

namespace Infrastructure.PocFunApi.Controllers
{
    public class JobApplicantsController : ApiController
    {
        private readonly IRecruiter _recruiter;

        public JobApplicantsController([Dependency("mongo")] IRecruiter mongoRecruiter)
        {
            _recruiter = mongoRecruiter;
        }

        // GET v1/jobapplicants
        public IList<JobApplicantDto> Get()
        {
            return _recruiter.GetApplicants();
        }

        // GET v1/jobs/0000-.../jobapplicants
        //[HttpGet("v1/jobs/{id}/jobapplicants")]
        public IList<JobApplicantDto> Get(Guid jobId)
        {
            return _recruiter.GetApplicants(jobId);
        }

        // POST v1/jobapplicants
        public JobApplicantDto Post(JobApplicantDto jobApplicant)
        {
            return _recruiter.AddNewApplicant(jobApplicant);
        }

        // PUT v1/jobapplicants/0000-...
        public JobApplicantDto Put(Guid id, JobApplicantDto jobApplicant)
        {
            return null;
        }

        // DELETE v1/jobapplicant/0000-...
        public void Delete(int id)
        {
        }
    }
}
