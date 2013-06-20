using System.Linq;

namespace Core.Domain.Services
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void Attach(T entity);  // Update step 1
        void SubmitChanges();   // Update step 2
    }
}
