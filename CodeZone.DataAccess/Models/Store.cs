using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Models
{
     public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StoreItem> StoreItems { get; set; }
    }
}
