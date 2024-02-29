using Core.Entities.Settings;
using Core.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<SystemUnitCategory> SystemUnitCategories { get; set; }

        public DbSet<InventoryMasterList> InventoryMasterLists { get; set; }
        public DbSet<InventoryOffices> InventoryOffices { get; set; }
        public DbSet<SystemUnitSpecs> SystemUnitSpecs { get; set; }
    }
}