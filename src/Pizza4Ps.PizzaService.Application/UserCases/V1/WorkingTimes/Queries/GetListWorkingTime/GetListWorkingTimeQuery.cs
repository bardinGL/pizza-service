using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTime
{
	public class GetListWorkingTimeQuery : IRequest<GetListWorkingTimeQueryResponse>
	{
		public GetListWorkingTimeDto GetListWorkingTimeDto { get; set; }
	}
}