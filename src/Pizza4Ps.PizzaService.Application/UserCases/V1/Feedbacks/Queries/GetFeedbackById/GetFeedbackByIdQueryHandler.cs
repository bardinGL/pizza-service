using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetFeedbackById
{
	public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, GetFeedbackByIdQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackRepository _feedbackRepository;

		public GetFeedbackByIdQueryHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
		{
			_mapper = mapper;
			_feedbackRepository = feedbackRepository;
		}

		public async Task<GetFeedbackByIdQueryResponse> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _feedbackRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<FeedbackDto>(entity);
			return new GetFeedbackByIdQueryResponse
			{
				Feedback = result
			};
		}
	}
}
