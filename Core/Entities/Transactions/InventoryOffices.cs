using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Settings;

namespace Core.Entities.Transactions
{
    public class InventoryOffices : BaseEntity
    {
        public string ControlNumber { get; set; }
        public Campus Campus { get; set; }
        public int CampusId { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
        public string DateIssued { get; set; }
    }
}