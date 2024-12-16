using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.UpdateFeedback
{
	public class UpdateFeedbackCommand : IRequest<UpdateFeedbackCommandResponse>
	{
		public Guid Id { get; set; }
		public UpdateFeedbackDto UpdateFeedbackDto { get; set; }
	}
}
