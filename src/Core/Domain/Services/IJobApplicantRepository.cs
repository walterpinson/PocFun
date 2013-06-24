using Core.Domain.Models;

namespace Core.Domain.Services
{
    public interface IJobApplicantRepository : IRepository<JobApplicant>
    {
        JobApplicant Get(string id);
    }
}
