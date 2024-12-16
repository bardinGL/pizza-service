using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.CreateFeedback
{
	public class CreateFeedbackCommand : IRequest<CreateFeedbackCommandResponse>
	{
		public CreateFeedbackDto CreateFeedbackDto { get; set; }
	}
}
