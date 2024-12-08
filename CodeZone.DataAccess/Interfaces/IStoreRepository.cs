using CodeZone.DataAccess.Models;

namespace CodeZone.DataAccess.Interfaces
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        void Update(Store store);
    }
}
