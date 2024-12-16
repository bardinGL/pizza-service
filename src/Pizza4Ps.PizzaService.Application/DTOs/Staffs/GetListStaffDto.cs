using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.Staffs
{
    public class GetListStaffDto : PaginatedRequestDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public StaffTypeEnum.StaffType? StaffType { get; set; }
        public StaffTypeEnum.StaffStatus? Status { get; set; }
    }
}
