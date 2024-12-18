using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedback
{
	public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, GetListFeedbackQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackRepository _feedbackRepository;

		public GetListFeedbackQueryHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
		{
			_mapper = mapper;
			_feedbackRepository = feedbackRepository;
		}

		public async Task<GetListFeedbackQueryResponse> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
		{
			var query = _feedbackRepository.GetListAsNoTracking(
				x => (request.GetListFeedbackDto.Rating == null || x.Rating == request.GetListFeedbackDto.Rating)
				&& (request.GetListFeedbackDto.Comments == null || x.Comments.Contains(request.GetListFeedbackDto.Comments))
				&& (request.GetListFeedbackDto.OrderId == null || x.OrderId == request.GetListFeedbackDto.OrderId),
				includeProperties: request.GetListFeedbackDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListFeedbackDto.SortBy)
				.Skip(request.GetListFeedbackDto.SkipCount).Take(request.GetListFeedbackDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.FeedbackErrorConstant.FEEDBACK_NOT_FOUND);
			var result = _mapper.Map<List<FeedbackDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListFeedbackQueryResponse(result, totalCount);
		}
	}
}
