using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetProductById;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetStaffById
{
	public class GetStaffByIdQuery : IRequest<GetStaffByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
