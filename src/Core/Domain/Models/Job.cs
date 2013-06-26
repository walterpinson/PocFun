using System;
using System.Collections.Generic;

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

        public Job()
        {
            // TODO: intentionally not settig the Id here.  Will let the database handle that.  ...for now.
            IsFilled = false;
        }

        public bool AcceptApplication(JobApplication application)
        {
            var accepted = false;

            if (null == application)
                throw new Exception();

            if (null == Applications)
                Applications = new List<JobApplication>();

            application.Position = this;
            Applications.Add(application);
            accepted = true;

            return accepted;
        }

        public bool Fill(JobApplicant personHired)
        {
            if (IsFilled)
                throw new Exception();

            if (null == personHired)
                throw new Exception();

            PersonHired = personHired;
            IsFilled = true;

            return IsFilled;
        }
    }
}
