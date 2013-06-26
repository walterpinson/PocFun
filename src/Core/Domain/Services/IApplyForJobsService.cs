using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Domain.Services
{
    public interface IApplyForJobsService
    {
        void SubmitApplication(JobApplicant applicant, Job job);
    }
}
