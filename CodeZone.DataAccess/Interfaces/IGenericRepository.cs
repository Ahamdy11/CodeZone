

namespace CodeZone.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class         // T --> Models
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
       
    }
}
