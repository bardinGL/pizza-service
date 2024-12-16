using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.CreateFeedback
{
	public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreateFeedbackCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackService _feedbackService;

		public CreateFeedbackCommandHandler(IMapper mapper, IFeedbackService feedbackService)
		{
			_mapper = mapper;
			_feedbackService = feedbackService;
		}

		public async Task<CreateFeedbackCommandResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
		{
			var result = await _feedbackService.CreateAsync(
				request.CreateFeedbackDto.Rating,
				request.CreateFeedbackDto.Comments,
				request.CreateFeedbackDto.OrderId);
			return new CreateFeedbackCommandResponse
			{
				Id = result
			};
		}
	}
}
