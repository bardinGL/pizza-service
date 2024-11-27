using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Booking : EntityAuditBase<Guid>
    {
        public DateOnly BookingDate { get; set; }
        public TimeOnly BookingTime { get; set; }

        public int GuestCount { get; set; }
        public BookingTypeEnum Status { get; set; }
        public Guid CustomerId {  get; set; }
        public Guid TableforBookingId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BookingTable TableforBooking { get; set; }


        private Booking()
        {
        }

        public Booking(Guid id, DateOnly bookingDate, TimeOnly bookingTime, int guestsCount, BookingTypeEnum status, Guid customerId, Guid tableforBookingId)
        {
            Id = id;
            BookingDate = bookingDate;
            BookingTime = bookingTime;
            GuestCount = guestsCount;
            Status = status;
            CustomerId = customerId;
            TableforBookingId = tableforBookingId;
        }
    }
}
    