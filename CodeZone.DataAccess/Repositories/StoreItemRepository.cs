using CodeZone.DataAccess.Data;
using CodeZone.DataAccess.Interfaces;
using CodeZone.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Repositories
{
    public class StoreItemRepository : GenericRepository<StoreItem>, IStoreItemRepository
    {
        private readonly ApplicationDbContext _context;

        public StoreItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public StoreItem GetByStoreAndItem(int storeId, int itemId)
        {
            return _context.StoreItems.FirstOrDefault(si => si.StoreId == storeId && si.ItemId == itemId);
        }

        public void Update(StoreItem storeItem)
        {
            _context.StoreItems.Update(storeItem);
        }
    }
}
