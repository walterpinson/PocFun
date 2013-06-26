﻿using System;
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

        public void AcceptApplication(JobApplication application)
        {
            if (null == application)
                throw new Exception();

            if (null == Applications)
                Applications = new List<JobApplication>();

            Applications.Add(application);
        }

        public void Fill(JobApplicant personHired)
        {
            if (null != personHired)
            {
                PersonHired = personHired;
                IsFilled = true;
            }
        }
    }
}
