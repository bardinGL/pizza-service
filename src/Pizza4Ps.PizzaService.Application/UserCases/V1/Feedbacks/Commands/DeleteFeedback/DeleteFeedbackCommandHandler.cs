using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.DeleteFeedback
{
	public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand>
	{
		private readonly IFeedbackService _feedbackService;

		public DeleteFeedbackCommandHandler(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		public async Task Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
		{
			await _feedbackService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
