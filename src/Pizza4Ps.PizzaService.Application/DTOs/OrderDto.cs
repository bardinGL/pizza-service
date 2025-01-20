﻿namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string Status { get; set; }
        public Guid TableId { get; set; }

        public virtual TableDto Table { get; set; }
    }
}
