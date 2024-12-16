using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.DeleteFeedback
{
	public class DeleteFeedbackCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
		public bool isHardDelete { get; set; }
	}
}
