using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetWorkingTimeById
{
	public class GetWorkingTimeByIdQuery : IRequest<GetWorkingTimeByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
