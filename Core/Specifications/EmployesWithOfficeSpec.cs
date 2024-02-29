using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;
using Core.Parameters;

namespace Core.Specifications
{
    public class EmployesWithOfficeSpec : BaseSpecification<Employee>
    {
        public EmployesWithOfficeSpec(EmployeeParams employeeParams)
        : base(x =>
            (string.IsNullOrEmpty(employeeParams.Search) 
            || x.LastName.ToLower().Contains(employeeParams.Search)
            || x.FirstName.ToLower().Contains(employeeParams.Search)
            || x.MiddleName.ToLower().Contains(employeeParams.Search)) && 
            (employeeParams.OfficeId.HasValue || x.OfficeId == employeeParams.OfficeId)
        )
        {
            AddInclude(x => x.Office);
            AddOrderBy(x => x.Id);

        }
        
    }
}