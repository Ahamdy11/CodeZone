
namespace CodeZone.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStoreRepository Store { get; }
        IItemRepository Item { get; }
        int Complete();
    }
}
