﻿using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Zone : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ZoneTypeEnum Type { get; set; }

        public virtual ICollection<Table> Tables { get; set; }

        private Zone()
        {
        }

        public Zone(Guid id, string name, string description, ZoneTypeEnum type)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
        }

        public void UpdateZone(string name, string description, ZoneTypeEnum type)
        {
            Name = name;
            Description = description;
            Type = type;
        }
    }
}
