using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Products;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Queries.GetListStaff
{
    public class GetListStaffQueryResponse : PaginatedResultDto<StaffDto>
    {
        public GetListStaffQueryResponse(List<StaffDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
