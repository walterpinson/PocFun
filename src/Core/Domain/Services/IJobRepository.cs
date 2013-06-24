using System;
using Core.Domain.Models;

namespace Core.Domain.Services
{
    public interface IJobRepository : IRepository<Job>
    {
        Job Get(Guid id);
    }
}
