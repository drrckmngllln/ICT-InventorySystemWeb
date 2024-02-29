using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class DepartmentsController : BaseApiController
    {
        private readonly ISettingService<Department> _departmentRepo;
        public DepartmentsController(ISettingService<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetCampusesAsync()
        {
            return Ok(await _departmentRepo.GetAllAsync());
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetCampusBySearchAsync([FromQuery] string value)
        {
            var campuses = await _departmentRepo.GetAllAsync();
            var search = campuses.Where(x => x.Name.ToLower().Contains(value)).ToList();
            return Ok(search);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Department>> CreateAsync(Department campus)
        {
            var item = new Department
            {
                Name = campus.Name
            };
            if (item != null)
            {
                await _departmentRepo.AddAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult<Department>> UpdateAsync(Department campus)
        {
            var item = new Department
            {
                Id = campus.Id
            };
            if (item != null)
            {
                await _departmentRepo.UpdateAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> DeleteAsync(Department campus)
        {
            var item = new Department
            {
                Id = campus.Id
            };
            if (item != null)
            {
                await _departmentRepo.DeleteAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }
    }
}