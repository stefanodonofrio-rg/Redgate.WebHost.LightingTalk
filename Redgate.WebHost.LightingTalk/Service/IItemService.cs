using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Redgate.WebHost.LightingTalk.Service
{
    public interface IItemService
    {
        void AddItem(string itemName);

        IEnumerable<string> GetItem();
    }
}
