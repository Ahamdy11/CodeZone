using CodeZone.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Interfaces
{
    public interface IStoreItemRepository : IGenericRepository<StoreItem>
    {
        StoreItem GetByStoreAndItem(int storeId, int itemId);
        void Update(StoreItem storeItem);
    }
}
