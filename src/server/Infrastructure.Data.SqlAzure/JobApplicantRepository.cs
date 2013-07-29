using System;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;

namespace Infrastructure.Data.SqlAzure
{
    public class JobApplicantRepository : EfRepositoryBase<PocFunDbContext>, IJobApplicantRepository
    {
        public JobApplicant Get(Guid id)
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
            var operation = Add(entity);
            JobApplicant newApplicant = null;

            if (operation.Status)
                newApplicant = entity;

            return newApplicant;
        }

        public JobApplicant Update(JobApplicant entity)
        {
            var operation = Save(entity);
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
