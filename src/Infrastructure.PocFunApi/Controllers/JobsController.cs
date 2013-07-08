using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Application.Messages;
using Core.Application.Services;
using Microsoft.Practices.Unity;

namespace Infrastructure.PocFunApi.Controllers
{
    public class JobsController : ApiController
    {
        private readonly IRecruiter _recruiter;
/*
//        private readonly IRecruiter _mongoRecruiter;
//        private readonly IRecruiter _sqlRecruiter;

        public JobController([Dependency("mongo")] IRecruiter mongoRecruiter, [Dependency("sql")] IRecruiter sqlRecruiter)
        {
            _mongoRecruiter = mongoRecruiter;
            _sqlRecruiter = sqlRecruiter;
        }
*/

        public JobsController([Dependency("mongo")] IRecruiter mongoRecruiter)
        {
            _recruiter = mongoRecruiter;
        }

        // GET v1/jobs
        // for some reason I cannot get attribute routing to work.  It's like I have the
        // wrong version of WebAPI installed, or something  :-/
//        [HttpGet("v1/jobs")]
        public IList<JobDto> Get()
        {
            return _recruiter.GetJobs();
        }

        // GET v1/jobs/0000-...
        public JobDto Get(Guid id)
        {
            return _recruiter.GetJob(id);
        }

        // POST v1/jobs
        public JobDto Post(JobDto job)
        {
            return _recruiter.AddNewJob(job);
        }

        // PUT v1/jobs/0000-...
        public JobDto Put(int id, JobDto job)
        {
            return null;
        }

        // DELETE v1/jobs/0000-...
        public void Delete(int id)
        {
        }
    }
}
