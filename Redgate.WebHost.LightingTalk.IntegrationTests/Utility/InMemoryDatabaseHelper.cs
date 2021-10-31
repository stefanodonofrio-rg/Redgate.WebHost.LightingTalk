using System;
using System.Collections.Generic;
using System.Linq;
using Redgate.WebHost.LightingTalk.Data;

namespace Redgate.WebHost.LightingTalk.IntegrationTests.Utility
{
    public static class InMemoryDatabaseHelper
    {
        public static List<Item> InMemoryItems = new List<Item>
        {
            new() { Id = Guid.NewGuid(), Value = "TestValue1" },
            new() { Id = Guid.NewGuid(), Value = "TestValue2" }
        };
        
        public static void InitializeDb(ItemContext context)
        {
            context.Database.EnsureCreated();
            
            if(context.Items.Any()) return;

            context.Items.AddRange(InMemoryItems);
            context.SaveChanges();
        }
    }
}