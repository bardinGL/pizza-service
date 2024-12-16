using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.RestoreFeedback
{
	public class RestoreFeedbackCommandHandler : IRequestHandler<RestoreFeedbackCommand>
	{
		private readonly IFeedbackService _feedbackService;

		public RestoreFeedbackCommandHandler(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		public async Task Handle(RestoreFeedbackCommand request, CancellationToken cancellationToken)
		{
			await _feedbackService.RestoreAsync(request.Ids);
		}
	}
}
