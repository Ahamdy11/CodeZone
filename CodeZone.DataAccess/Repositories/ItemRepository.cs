using CodeZone.DataAccess.Data;
using CodeZone.DataAccess.Interfaces;
using CodeZone.DataAccess.Models;


namespace CodeZone.DataAccess.Repositories
{
    public class ItemRepository:GenericRepository<Item>,IItemRepository
    {
        private readonly ApplicationDbContext _context;
        public ItemRepository(ApplicationDbContext context): base(context)
        {
            _context = context;        
        }

        public void Update(Item item)
        {
           var ItemInDb = _context.Items.Find(item.Id);
            if (ItemInDb!=null)
            {
                _context.Entry(ItemInDb).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
        }
    }
}
