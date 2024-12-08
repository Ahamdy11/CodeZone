﻿using CodeZone.DataAccess.Data;
using CodeZone.DataAccess.Interfaces;
using CodeZone.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Repositories
{
    public class StoreRepository : GenericRepository<Store>, IStoreRepository
    {
        private readonly ApplicationDbContext _context;
        public StoreRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Store store)
        {
            var StoreInDb = _context.Stores.Find(store.Id);
            if (StoreInDb != null)
            {
                _context.Entry(StoreInDb).CurrentValues.SetValues(store);
                _context.SaveChanges();
            }
        }
    }
}
