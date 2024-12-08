
namespace CodeZone.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStoreRepository Store { get; }
        IItemRepository Item { get; }
        IStoreItemRepository StoreItem { get; }
        int Complete();
    }
}
