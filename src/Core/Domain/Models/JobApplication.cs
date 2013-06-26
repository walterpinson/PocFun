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
        public virtual JobApplicant Applicant { get; set; }
        public Guid ApplicantId { get; set; }
        public virtual Job Position { get; set; }
        public Guid PositionId { get; set; }

        public JobApplication()
        {
            Date = DateTime.Now;
        }
    }
}
