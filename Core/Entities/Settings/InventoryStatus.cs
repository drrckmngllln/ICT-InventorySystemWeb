using System.Runtime.Serialization;

namespace Core.Entities.Settings
{
    public enum InventoryStatus
    {
        [EnumMember(Value = "Functional")]
        Functional,
        [EnumMember(Value = "Non-Functional")]

        NonFunctional,
        [EnumMember(Value = "Under Repair")]

        UnderRepair,
        [EnumMember(Value = "For Disposal")]

        ForDisposal
    }
}