using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;

namespace Core.Entities.Transactions
{
    public class InventoryMasterList : BaseEntity
    {
        public InventoryOffices Office { get; set; }
        public int OfficeId { get; set; }
        public InventoryCategory Category { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string YearPurchased { get; set; }
        public string SerialNumber { get; set; }
        public Employee RequestingPerson { get; set; }
        public int RequestingPersonId { get; set; }
        public InventoryStatus Status { get; set; } = InventoryStatus.Functional;
        public string Remarks { get; set; }
    }
}