using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Messages
{
    public class JobApplicationDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public virtual JobApplicantDto Applicant { get; set; }
        public virtual JobDto Position { get; set; }
    }
}
