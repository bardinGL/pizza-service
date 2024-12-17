using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter
{
	public class GetListOrderItemIgnoreQueryFilterQuery : IRequest<GetListOrderItemIgnoreQueryFilterQueryResponse>
	{
		public GetListOrderItemIgnoreQueryFilterDto GetListOrderItemIgnoreQueryFilterDto { get; set; }
	}
}
