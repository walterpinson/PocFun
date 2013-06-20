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
        public JobApplicant Get(string id)
        {
            return Get<JobApplicant>(ja => ja.Id == id);
        }

        public JobApplicant Get(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JobApplicant> GetAll()
        {
            return GetList<JobApplicant>();
        }

        public JobApplicant Create(JobApplicant entity)
        {
            var operation = Add<JobApplicant>(entity);
            JobApplicant updatedApplicant = null;

            if (operation.Status)
                updatedApplicant = entity;

            return updatedApplicant;
        }

        public JobApplicant Update(JobApplicant entity)
        {
            var operation = Update<JobApplicant>(entity);
            JobApplicant updatedApplicant = null;

            if (operation.Status)
                updatedApplicant = entity;

            return updatedApplicant;
        }

        public void Delete(JobApplicant entity)
        {
            Delete<JobApplicant>(entity);
        }
    }
}
