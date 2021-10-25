using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redgate.WebHost.LightingTalk.Service
{
    public class ItemService : IItemService
    {
        List<string> m_ItemStorage;

        public ItemService()
        {
            m_ItemStorage = new List<string>(new[] { "Initial Item" });
        }

        public IEnumerable<string> GetItem() => m_ItemStorage;

        public void AddItem(string itemName)
        {
            if(!string.IsNullOrEmpty(itemName))
            {
                m_ItemStorage.Add(itemName);
            }
        }
    }
}
