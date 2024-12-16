using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Zone : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public ZoneTypeEnum Status { get; set; } = ZoneTypeEnum.Available;

        private Zone()
        {
        }

        public Zone(Guid id, string name, int capacity, string description, ZoneTypeEnum status)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            Description = description;
            Status = status;
        }

        public void UpdateZone(string name, int capacity, string description, ZoneTypeEnum status)
        {
            Name = name;
            Capacity = capacity;
            Description = description;
            Status = status;
        }
    }
}
