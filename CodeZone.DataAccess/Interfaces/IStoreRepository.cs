using CodeZone.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Interfaces
{
    public interface IStoreRepository : IGenericRepository<Store>
    {
        void Update(Store store);
    }
}
