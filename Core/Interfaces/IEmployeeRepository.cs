using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IReadOnlyList<Employee>> GetAllAsync();
        Task<IReadOnlyList<Employee>> GetAllBySearch(string value);
        Task AddAsync(Employee entity);
        Task UpdateAsync(Employee entity);
        Task DeleteAsync(Employee entity);
    }
}