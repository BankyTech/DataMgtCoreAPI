using System.Collections.Generic;

namespace DataManagement.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Add(T entity);        
        void Delete(T entity);
        void Update(T entity);
    }
}
