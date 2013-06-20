using System;

namespace Core.Domain.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Salary { get; set; }
        public bool IsFilled { get; set; }
        public Guid PersonHiredId { get; set; }
        public JobApplicant PersonHired { get; set; }
        public virtual IList<JobApplicant> Applicants {get;set;}


        public void Fill(JobApplicant personHired)
        {
            PersonHired = personHired;
        }
    }
}
