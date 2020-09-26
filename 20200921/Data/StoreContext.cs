using System;
using Microsoft.EntityFrameworkCore;
using _20200921.Models;

namespace _20200921.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}