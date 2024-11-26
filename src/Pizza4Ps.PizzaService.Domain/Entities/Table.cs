using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Table : EntityAuditBase<Guid>
    {
        public string TableNumber { get; set; }
        public TableTypeEnum TableStatus { get; set; }
        public int SeatingCapacity { get; set; }
        public Guid TableforBookingId { get; set; }
        public Guid ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
        
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<OrderInTable> OrdersInTable { get; set; }
        
        public virtual TableForBooking TableforBooking { get; set; }

        private Table()
        {
        }

        public Table(Guid id, string tableNumber, TableTypeEnum tablestatus, int seatingCapacity, Guid zoneId, Zone zone, Guid tableforBookingId)
        {
            Id = id;
            TableNumber = tableNumber;
            TableStatus = tablestatus;
            SeatingCapacity = seatingCapacity;
            ZoneId = zoneId;
            TableforBookingId = tableforBookingId;
        }
    }
}
