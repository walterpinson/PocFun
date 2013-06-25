using System.Linq;

namespace Core.Domain.Services
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);
        IQueryable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
