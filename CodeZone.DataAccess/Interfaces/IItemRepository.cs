using CodeZone.DataAccess.Models;


namespace CodeZone.DataAccess.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        void Update(Item item);
    }
}
