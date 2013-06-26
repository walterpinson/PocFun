using System;
using System.Linq;
using Core.Domain.Models;
using Core.Domain.Services;

namespace Infrastructure.Data.SqlAzure
{
    public class JobRepository : EfRepositoryBase<PocFunDbContext>, IJobRepository
    {
        #region Implementation of IRepository<Job>

        public Job Get(object id)
        {
            throw new NotImplementedException();
        }

        public Job Get(Guid id)
        {
            return Get<Job>(j => j.Id == id);
        }

        public IQueryable<Job> GetAll()
        {
            return GetList<Job>();
        }

        public Job Create(Job entity)
        {
            var operation = Add(entity);
            Job newJob = null;

            if (operation.Status)
                newJob = entity;

            return newJob;
        }

        public Job Update(Job entity)
        {
            var operation = Save<Job>(entity);
            Job updatedJob = null;

            if (operation.Status)
                updatedJob = entity;

            return updatedJob;
        }

        public void Delete(Job entity)
        {
            Delete<Job>(entity);
        }

        #endregion
    }
}
