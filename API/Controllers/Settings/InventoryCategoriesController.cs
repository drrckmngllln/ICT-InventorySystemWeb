using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class InventoryCategoriesController : BaseApiController
    {
        private readonly ISettingService<InventoryCategory> _repo;
        public InventoryCategoriesController(ISettingService<InventoryCategory> repo)
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InventoryCategory>>> GetAsync()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<InventoryCategory>>> GetBySearchAsync([FromQuery] string value)
        {
            var campuses = await _repo.GetAllAsync();
            var search = campuses.Where(x => x.Name.ToLower().Contains(value)).ToList();
            return Ok(search);
        }

        [HttpPost("create")]
        public async Task<ActionResult<InventoryCategory>> CreateAsync(InventoryCategory campus)
        {
            var item = new InventoryCategory
            {
                Name = campus.Name,
            };
            if (item != null)
            {
                await _repo.AddAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult<InventoryCategory>> UpdateAsync(InventoryCategory campus)
        {
            var item = new InventoryCategory
            {
                Id = campus.Id,
            };
            if (item != null)
            {
                await _repo.UpdateAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryCategory>> DeleteAsync(InventoryCategory campus)
        {
            var item = new InventoryCategory
            {
                Id = campus.Id
            };
            if (item != null)
            {
                await _repo.DeleteAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }
    }
}