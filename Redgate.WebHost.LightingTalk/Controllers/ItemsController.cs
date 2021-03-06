using Microsoft.AspNetCore.Mvc;
using Redgate.WebHost.LightingTalk.Service;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "CanRead")]
        public async Task<IActionResult> GetItem()
        {
            var items = m_ItemService.GetItem();
            return Ok(items);
        }

        [HttpPost("Add")]
        [Authorize(Policy = "CanAdd")]
        public async Task<IActionResult> AddItem([FromBody] string itemName)
        {
            m_ItemService.AddItem(itemName);
            return Ok();
        }
    }
}
