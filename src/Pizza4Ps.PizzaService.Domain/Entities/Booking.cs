using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Booking : EntityAuditBase<Guid>
    {
        public DateTime BookingDate { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }
        public Guid CustomerId { get; set; }
        public Guid TableBookingId { get; set; }

        public virtual Customer Customer { get; set; }

        private Booking()
        {
        }

        public Booking(Guid id, DateTime bookingDate, int guestCount, string status, Guid customerId, Guid tableBookingId)
        {
            Id = id;
            BookingDate = bookingDate;
            GuestCount = guestCount;
            Status = status;
            CustomerId = customerId;
            TableBookingId = tableBookingId;
        }

        public void UpdateBooking(DateTime bookingDate, int guestCount, string status, Guid customerId, Guid tableBookingId)
        {
            BookingDate = bookingDate;
            GuestCount = guestCount;
            Status = status;
            CustomerId = customerId;
            TableBookingId = tableBookingId;
        }
    }
}
