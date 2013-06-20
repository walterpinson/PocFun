using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;
using Core.Domain.Services;

namespace Infrastructure.Data.SqlAzure
{
    public class JobApplicantRepository : EfRepositoryBase<PocFunDbContext>, IJobApplicantRepository
    {
        public JobApplicant Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public JobApplicant Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JobApplicant> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(JobApplicant entity)
        {
            throw new NotImplementedException();
        }

        public void Update(JobApplicant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(JobApplicant entity)
        {
            throw new NotImplementedException();
        }
    }
}
