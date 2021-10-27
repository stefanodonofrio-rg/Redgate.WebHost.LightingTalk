using System;
using Microsoft.EntityFrameworkCore;

namespace Redgate.WebHost.LightingTalk.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {
        }
        
        public DbSet<Item> Items { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}