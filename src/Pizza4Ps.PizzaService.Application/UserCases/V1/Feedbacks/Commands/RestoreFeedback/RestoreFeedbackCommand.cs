using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.RestoreFeedback
{
	public class RestoreFeedbackCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
