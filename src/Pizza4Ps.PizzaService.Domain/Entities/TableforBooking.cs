using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class TableForBooking : EntityAuditBase<Guid>
    {
        public DateTime OnholdTime { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        private TableForBooking() { }

        public TableForBooking(Guid id, DateTime onholdtime)
        {
            Id = id;
            OnholdTime = onholdtime;
        }
    }
}
