using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _ItemRepository;

        public ItemController(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        // GET: api/Item
        [HttpGet]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier},{Role.Viewer}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var Items = await _ItemRepository.GetAllAsync();
            return Ok(Items);
        }

        // GET: api/Item/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier},{Role.Viewer}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var Item = await _ItemRepository.GetByIdAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }

        // POST: api/Item
        [HttpPost]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier}")]
        public async Task<ActionResult<Item>> CreateItem(Item item)
        {
            if (item == null)
            {
                return BadRequest("Item data is null.");
            }

            var createdItem = await _ItemRepository.AddAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/Item/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier}")]
        public async Task<IActionResult> UpdateItem(int id, Item Item)
        {
            if (id != Item.Id)
            {
                return BadRequest("Item ID mismatch.");
            }

            var existingItem = await _ItemRepository.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _ItemRepository.UpdateAsync(Item);
            return NoContent();
        }

        // DELETE: api/Item/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Role.Admin},{Role.Modifier}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var Item = await _ItemRepository.GetByIdAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            await _ItemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}