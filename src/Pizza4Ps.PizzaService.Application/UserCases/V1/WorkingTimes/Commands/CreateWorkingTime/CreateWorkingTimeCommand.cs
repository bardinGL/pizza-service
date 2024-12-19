using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.CreateWorkingTime
{
	public class CreateWorkingTimeCommand : IRequest<CreateWorkingTimeCommandResponse>
	{
		public CreateWorkingTimeDto CreateWorkingTimeDto { get; set; }
	}
}
