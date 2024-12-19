using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.RestoreWorkingTime
{
	public class RestoreWorkingTimeCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
