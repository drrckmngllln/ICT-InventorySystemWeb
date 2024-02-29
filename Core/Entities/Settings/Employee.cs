using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Settings
{
    public class Employee : BaseEntity
    {
        public string EmployeeNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
    }
}