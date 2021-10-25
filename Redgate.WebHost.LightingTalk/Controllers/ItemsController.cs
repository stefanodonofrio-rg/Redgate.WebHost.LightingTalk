using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Redgate.WebHost.LightingTalk.Service;
using System.Threading.Tasks;

namespace Redgate.WebHost.LightingTalk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        readonly IItemService m_ItemService;

        public ItemsController(IItemService itemService)
        {
            m_ItemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetItem()
        {
            var items = m_ItemService.GetItem();
            return Ok(items);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddItem([FromBody] string itemName)
        {
            m_ItemService.AddItem(itemName);
            return Ok();
        }
    }
}
