using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class FeedBack : EntityAuditBase<Guid>
    {
        public string Description { get; set; }
        
    }
}
