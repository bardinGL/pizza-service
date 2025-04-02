﻿namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime BookingTime { get; set; }
        public int NumberOfPeople { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? TableId { get; set; }


        // Relations
        public virtual CustomerDto Customer { get; set; }
        public virtual TableDto? Table { get; set; }
    }
}
