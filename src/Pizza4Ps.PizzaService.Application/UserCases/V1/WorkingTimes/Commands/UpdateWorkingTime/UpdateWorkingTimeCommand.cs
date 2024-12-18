using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.UpdateWorkingTime
{
	public class UpdateWorkingTimeCommand : IRequest<UpdateWorkingTimeCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateWorkingTimeDto UpdateWorkingTimeDto { get; set; }
	}
}
