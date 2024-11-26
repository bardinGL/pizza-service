using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class BookingTable : EntityAuditBase<Guid>
    {
        public DateTime OnholdTime { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        private BookingTable() { }

        public BookingTable(Guid id, DateTime onholdtime)
        {
            Id = id;
            OnholdTime = onholdtime;
        }
    }
}
