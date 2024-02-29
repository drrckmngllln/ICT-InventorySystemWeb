using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Settings
{
    public class Campus : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}