using CodeZone.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeZone.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreItem>()
                .HasKey(si => new { si.StoreId, si.ItemId });

            modelBuilder.Entity<StoreItem>()
                .HasOne(si => si.Store)
                .WithMany(s => s.StoreItems)
                .HasForeignKey(si => si.StoreId);

            modelBuilder.Entity<StoreItem>()
                .HasOne(si => si.Item)
                .WithMany(i => i.StoreItems)
                .HasForeignKey(si => si.ItemId);

            base.OnModelCreating(modelBuilder);
        }

    }
}

