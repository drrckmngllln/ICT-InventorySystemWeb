using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class CampusesController : BaseApiController
    {
        private readonly ISettingService<Campus> _settingsRepo;
        public CampusesController(ISettingService<Campus> settingsRepo)
        {
            _settingsRepo = settingsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Campus>>> GetCampusesAsync()
        {
            return Ok(await _settingsRepo.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Campus>>> GetCampusBySearchAsync([FromQuery] string value)
        {
            var campuses = await _settingsRepo.GetAllAsync();
            var search = campuses.Where(x => x.Name.ToLower().Contains(value) || x.Description.ToLower().Contains(value)).ToList();
            return Ok(search);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Campus>> CreateAsync(Campus campus)
        {
            var item = new Campus
            {
                Name = campus.Name,
                Description = campus.Description
            };
            if (item != null)
            {
                await _settingsRepo.AddAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult<Campus>> UpdateAsync(Campus campus)
        {
            var item = new Campus
            {
                Id = campus.Id,
                Description = campus.Description
            };
            if (item != null)
            {
                await _settingsRepo.UpdateAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Campus>> DeleteAsync(Campus campus)
        {
            var item = new Campus
            {
                Id = campus.Id
            };
            if (item != null)
            {
                await _settingsRepo.DeleteAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }
    }
}