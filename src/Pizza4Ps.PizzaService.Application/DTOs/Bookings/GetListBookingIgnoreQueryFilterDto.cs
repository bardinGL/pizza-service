using Pizza4Ps.PizzaService.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.DTOs.Bookings
{
    public class GetListBookingIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime BookingDate { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid TableBookingId { get; set; }
    }
}
