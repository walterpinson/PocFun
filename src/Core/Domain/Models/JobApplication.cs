using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class JobApplication : IJobApplication
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public JobApplicant Applicant { get; set; }
        public Job Position { get; set; }

        public JobApplication()
        {
            Date = DateTime.Now;
        }
    }
}
