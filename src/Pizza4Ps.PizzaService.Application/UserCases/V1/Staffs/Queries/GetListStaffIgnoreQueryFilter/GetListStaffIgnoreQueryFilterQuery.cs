using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetListStaffIgnoreQueryFilter
{
	public class GetListStaffIgnoreQueryFilterQuery : IRequest<GetListStaffIgnoreQueryFilterQueryResponse>
	{
		public GetListStaffIgnoreQueryFilterDto GetListStaffIgnoreQueryFilterDto { get; set; }
	}
}
