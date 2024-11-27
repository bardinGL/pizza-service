using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Staff : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public StaffTypeEnum StaffType { get; set; }
        public Guid StaffZoneId { get; set; }
        public virtual StaffZone StaffZone { get; set; }
        private Staff() { }
        public Staff(Guid id ,string code, string name, string phoneNumber, string email, StaffTypeEnum staffType, Guid staffZoneId)
        {
            Id = id;
            Code = code;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            StaffType = staffType;
            StaffZoneId = staffZoneId;
        }
    }
}
