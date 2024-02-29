using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities.Settings;
using Core.Interfaces;
using Core.Parameters;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Settings
{
    public class EmployeesController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepo;
        public EmployeesController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> GetCampusesAsync([FromQuery] EmployeeParams employeeParams)
        {
            var employee = await _employeeRepo.GetAllAsync();
            var data = _mapper.Map<IReadOnlyList<Employee>, IReadOnlyList<EmployeeDto>>(employee);
            return Ok(data);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IReadOnlyList<Employee>>> GetCampusBySearchAsync([FromQuery] string value)
        {
            var campuses = await _employeeRepo.GetAllAsync();
            var search = campuses.Where(x => x.LastName.ToLower().Contains(value)).ToList();
            return Ok(search);
        }

        [HttpPost("create")]
        public async Task<ActionResult<EmployeeDto>> CreateAsync(Employee employee)
        {
            var item = new Employee
            {
                EmployeeNumber = employee.EmployeeNumber,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                OfficeId = employee.OfficeId
            };
            if (item != null)
            {
                await _employeeRepo.AddAsync(item);
                return Ok(_mapper.Map<Employee, EmployeeDto>(item));
            }
            

            return BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult<Employee>> UpdateAsync(Employee employee)
        {
            var item = new Employee
            {
                Id = employee.Id,
                EmployeeNumber = employee.EmployeeNumber,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                OfficeId = employee.OfficeId
            };
            if (item != null)
            {
                await _employeeRepo.UpdateAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteAsync(Employee employee)
        {
            var item = new Employee
            {
                Id = employee.Id
            };
            if (item != null)
            {
                await _employeeRepo.DeleteAsync(item);
                return Ok(item);
            }

            return BadRequest();
        }
    }
}