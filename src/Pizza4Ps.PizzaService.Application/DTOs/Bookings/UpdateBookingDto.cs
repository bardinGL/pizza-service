namespace Pizza4Ps.PizzaService.Application.DTOs.Bookings
{
    public class UpdateBookingDto
    {
        public DateTime BookingDate { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
    }
}
