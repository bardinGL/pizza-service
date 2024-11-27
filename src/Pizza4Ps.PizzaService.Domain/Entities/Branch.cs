using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Branch : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Location { get; set; }
        public BranchTypeEnum BranchStatus { get; set;}
        public virtual ICollection<Booking> Bookings { get; set; }

        private Branch() { }

        public Branch(string name, string description, decimal phoneNumber, string location, BranchTypeEnum branchstatus)
        {
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            Location = location;
            BranchStatus = branchstatus;
        }
    }
}
