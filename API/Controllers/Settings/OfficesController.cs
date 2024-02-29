using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class OfficesController : BaseApiController
    {
        private readonly ISettingService<Office> _repo;
        public OfficesController(ISettingService<Office> repo)
        {
            _repo = repo;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Office>>> GetAsync()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Office>>> GetBySearchAsync([FromQuery] string value)
        {
            var campuses = await _repo.GetAllAsync();
            var search = campuses.Where(x => x.Name.ToLower().Contains(value)).ToList();
            return Ok(search);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Office>> CreateAsync(Office campus)
        {
            var item = new Office
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
        public async Task<ActionResult<Office>> UpdateAsync(Office campus)
        {
            var item = new Office
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
        public async Task<ActionResult<Office>> DeleteAsync(Office campus)
        {
            var item = new Office
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