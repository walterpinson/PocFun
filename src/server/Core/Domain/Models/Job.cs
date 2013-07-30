using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Services;

namespace Core.Domain.Models
{
    public class Job : IJob
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public bool IsFilled { get; set; }
        public Guid? PersonHiredId { get; set; }
        public virtual JobApplicant PersonHired { get; set; }
        public virtual IList<JobApplication> Applications { get; set; }

        private IJobRepository _jobRepository;

        public Job():this(null) {}

        public Job(IJobRepository jobRepository)
        {
            // TODO: intentionally not settig the Id here.  Will let the database handle that.  ...for now.
            IsFilled = false;
            _jobRepository = jobRepository;
        }

        public void Initialize(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public JobApplication AcceptApplication(JobApplication application)
        {
            if (null == application)
                throw new Exception();

            if (null == Applications)
                Applications = new List<JobApplication>();

            JobApplication app = null;

            try
            {
                application.JobId = Id;
                Applications.Add(application);
                app = _jobRepository.Update(this).Applications[Applications.Count - 1];
            }
            catch(Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e);
            }

//            return accepted;
            return app;
        }

        public bool Fill(JobApplicant personHired)
        {
            if (IsFilled)
                throw new Exception();

            if (null == personHired)
                throw new Exception();

            try
            {
                PersonHired = personHired;
                IsFilled = true;
            }
            catch(Exception)
            {
                IsFilled = false;
            }

            return IsFilled;
        }

        public IList<Guid> GetApplicants()
        {
            return Applications.Select(app => app.JobApplicantId).ToList();
        } 
    }
}
