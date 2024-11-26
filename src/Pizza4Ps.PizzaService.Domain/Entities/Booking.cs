using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Booking : EntityAuditBase<Guid>
    {
        public DateTime BookingDate { get; set; }
        public int NumberOfGuests { get; set; }
        public Guid CustomerId {  get; set; }
        public Guid TableforBookingId { get; set; }
        public Guid RestaurantId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BookingTable TableforBooking { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        private Booking()
        {
        }

        public Booking(Guid id, DateTime bookingDate, int numberOfGuests, Guid customerId, Guid tableforBookingId, Guid restaurantId)
        {
            Id = id;
            BookingDate = bookingDate;
            NumberOfGuests = numberOfGuests;
            CustomerId = customerId;
            TableforBookingId = tableforBookingId;
            RestaurantId = restaurantId;
        }
    }
}
    