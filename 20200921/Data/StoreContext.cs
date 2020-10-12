using System;
using Microsoft.EntityFrameworkCore;
using _20200921.Models;

namespace _20200921.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Item)
                .WithMany(i => i.Reviews)
                .IsRequired();
        }
    }
}