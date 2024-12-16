using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.UpdateFeedback
{
	public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, UpdateFeedbackCommandResponse>
	{
		private readonly IFeedbackService _feedbackService;

		public UpdateFeedbackCommandHandler(IFeedbackService feedbackService)
		{
			_feedbackService = feedbackService;
		}

		public async Task<UpdateFeedbackCommandResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
		{
			var result = await _feedbackService.UpdateAsync(
				request.Id,
				request.UpdateFeedbackDto.Rating,
				request.UpdateFeedbackDto.Comments,
				request.UpdateFeedbackDto.OrderId);
			return new UpdateFeedbackCommandResponse
			{
				Id = result
			};
		}
	}
}
