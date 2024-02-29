using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StoreContext _context;
        public EmployeeRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee entity)
        {
            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(x => x.Office)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Employee>> GetAllBySearch(string value)
        {
            return await _context.Employees
                .Include(x => x.Office)
                .Where(x => x.LastName.ToLower().Contains(value))
                .ToListAsync();
        }

        public async Task UpdateAsync(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}