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

        public Staff()
        {
        }

        public Staff(Guid id, string code, string name, string phone, string email, StaffTypeEnum.StaffType staffType, StaffTypeEnum.StaffStatus status)
        {
            Id = id;
            Code = code;
            Name = name;
            Phone = phone;
            Email = email;
            StaffType = staffType;
            Status = status;
        }

        public void UpdateStaff(string code, string name, string phone, string email, StaffTypeEnum.StaffType staffType, StaffTypeEnum.StaffStatus status)
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
