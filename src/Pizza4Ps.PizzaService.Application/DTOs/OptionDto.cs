﻿using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OptionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool SelectMany { get; set; }
        public string OptionStatus { get; set; }
        public ICollection<OptionItemDto> OptionItems { get; set; }
    }
}
