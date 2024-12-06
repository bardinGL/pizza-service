using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Staff : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public StaffTypeEnum.StaffType StaffType { get; set; }
        public StaffTypeEnum.StaffStatus Status { get; set; }

        public virtual ICollection<StaffZone> StaffZones { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedules { get; set; }

        public Staff()
        {
        }

        public Staff(string code, string name, string phone, string email, StaffEnum.StaffType staffType, StaffEnum.StaffStatus status)
        {
            Code = code;
            Name = name;
            Phone = phone;
            Email = email;
            StaffType = staffType;
            Status = status;
        }
    }
}
