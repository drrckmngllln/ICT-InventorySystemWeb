using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;

namespace Core.Entities.Transactions
{
    public class SystemUnitSpecs : BaseEntity
    {
        public InventoryMasterList ControlNumber { get; set; }
        public int ControlNumberId { get; set; }
        public SystemUnitCategory Category { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string YearPurchased { get; set; }
        public string SerialNumber { get; set; }
        public InventoryStatus Status { get; set; } = InventoryStatus.Functional;
        public string Remarks { get; set; }
    }
}