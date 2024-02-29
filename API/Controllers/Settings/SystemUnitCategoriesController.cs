using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class SystemUnitCategoriesController : BaseApiController
    {
        private readonly ISettingService<SystemUnitCategory> _repo;
        public SystemUnitCategoriesController(ISettingService<SystemUnitCategory> repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SystemUnitCategory>>> GetAsync()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<SystemUnitCategory>>> GetBySearchAsync([FromQuery] string value)
        {
            var campuses = await _repo.GetAllAsync();
            var search = campuses.Where(x => x.Name.ToLower().Contains(value)).ToList();
            return Ok(search);
        }

        [HttpPost("create")]
        public async Task<ActionResult<SystemUnitCategory>> CreateAsync(SystemUnitCategory campus)
        {
            var item = new SystemUnitCategory
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
        public async Task<ActionResult<SystemUnitCategory>> UpdateAsync(SystemUnitCategory campus)
        {
            var item = new SystemUnitCategory
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
        public async Task<ActionResult<SystemUnitCategory>> DeleteAsync(SystemUnitCategory campus)
        {
            var item = new SystemUnitCategory
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