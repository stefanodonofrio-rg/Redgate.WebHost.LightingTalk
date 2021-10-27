using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Redgate.WebHost.LightingTalk.Data;

namespace Redgate.WebHost.LightingTalk.Service
{
    public class ItemService : IItemService
    {
        private readonly ItemContext m_ItemContext;

        public ItemService(ItemContext itemContext)
        {
            m_ItemContext = itemContext;
        }

        public IEnumerable<string> GetItem() => m_ItemContext.Items.Select(x => x.Value).ToList();

        public void AddItem(string itemName)
        {
            if(!string.IsNullOrEmpty(itemName))
            {
                m_ItemContext.Items.Add(new Item { Id= Guid.NewGuid(), Value = itemName });
                m_ItemContext.SaveChanges();
            }
        }
    }
}
