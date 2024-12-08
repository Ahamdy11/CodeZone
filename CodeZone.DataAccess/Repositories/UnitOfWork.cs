﻿using CodeZone.DataAccess.Data;
using CodeZone.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IStoreRepository Store { get; private set; }
       // public IItemRepository Item { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Store = new StoreRepository(context);
          //  Item = new ItemRepository(context);
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