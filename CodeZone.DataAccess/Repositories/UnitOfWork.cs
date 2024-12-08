using CodeZone.DataAccess.Data;
using CodeZone.DataAccess.Interfaces;

namespace CodeZone.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStoreRepository Store { get; private set; }
        public IItemRepository Item { get; private set; }
        public IStoreItemRepository StoreItem { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Store = new StoreRepository(context);
            Item = new ItemRepository(context);
            StoreItem = new StoreItemRepository(context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
