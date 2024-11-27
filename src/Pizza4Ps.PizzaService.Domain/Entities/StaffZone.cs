using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class StaffZone : EntityAuditBase<Guid>
	{
        public Guid ZoneId { get; set; }
        public Guid StaffId { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual Staff Staff { get; set; }
        private StaffZone() { }
        public StaffZone(Guid id, Guid zoneId, Guid staffId)
        {
            Id = id;
            ZoneId = zoneId;
            StaffId = staffId;
        }
    }
}
