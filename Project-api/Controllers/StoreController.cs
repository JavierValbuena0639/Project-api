using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly StoreService _storeService;

        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Stores>>> GetAllStores()
        {
            var stores = await _storeService.GetAllStores();
            return Ok(stores);
        }

        [HttpGet("{storeId}")]
        public async Task<ActionResult<Stores>> GetStoreById(int storeId)
        {
            var store = await _storeService.GetStoreById(storeId);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }

        [HttpPost]
        public async Task<ActionResult<Stores>> CreateStore(Stores store)
        {
            var createdStore = await _storeService.CreateStore(store);
            return CreatedAtAction(nameof(GetStoreById), new { storeId = createdStore.IdStore }, createdStore);
        }

        [HttpPut("{storeId}")]
        public async Task<IActionResult> UpdateStore(int storeId, Stores store)
        {
            if (storeId != store.IdStore)
            {
                return BadRequest();
            }

            var updatedStore = await _storeService.UpdateStore(store);
            if (updatedStore == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{storeId}")]
        public async Task<IActionResult> DeleteStore(int storeId)
        {
            var result = await _storeService.DeleteStore(storeId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
