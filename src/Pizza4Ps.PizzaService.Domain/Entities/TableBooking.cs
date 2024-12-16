using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class TableBooking : EntityAuditBase<Guid>
    {
        public DateTime OnholdTime { get; set; }
        public Guid TableId { get; set; }
        public Guid BookingId { get; set; }

        public virtual Table Table { get; set; }
        public virtual Booking Booking { get; set; }

        private TableBooking()
        {
        }

        public TableBooking(Guid id ,DateTime onholdTime, Guid tableId, Guid bookingId, Table table, Booking booking)
        {
            Id = id;
            OnholdTime = onholdTime;
            TableId = tableId;
            BookingId = bookingId;
            Table = table;
            Booking = booking;
        }
    }
}
