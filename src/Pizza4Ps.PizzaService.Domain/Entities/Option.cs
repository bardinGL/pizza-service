﻿using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Option : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<OptionItem> OptionItems { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }

        public Option()
        {
        }

        public Option(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}