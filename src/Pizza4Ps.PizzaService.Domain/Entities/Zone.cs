using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Zone : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public string? Description { get; set; }
        public ZoneTypeEnum Status { get; set; } = ZoneTypeEnum.Available;

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<StaffZone> StaffZones { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedules { get; set; }

        private Zone()
        {
        }

        public Zone(string name, int? capacity, string? description, ZoneTypeEnum status)
        {
            Name = name;
            Capacity = capacity;
            Description = description;
            Status = status;
        }
    }
}
