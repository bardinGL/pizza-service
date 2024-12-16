using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedbackIgnoreQueryFilter
{
	public class GetListFeedbackIgnoreQueryFilterQueryHandler : IRequestHandler<GetListFeedbackIgnoreQueryFilterQuery, GetListFeedbackIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IFeedbackRepository _feedbackRepository;

		public GetListFeedbackIgnoreQueryFilterQueryHandler(IMapper mapper, IFeedbackRepository feedbackRepository)
		{
			_mapper = mapper;
			_feedbackRepository = feedbackRepository;
		}

		public async Task<GetListFeedbackIgnoreQueryFilterQueryResponse> Handle(GetListFeedbackIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _feedbackRepository.GetListAsNoTracking(includeProperties: request.GetListFeedbackIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListFeedbackIgnoreQueryFilterDto.Rating == null || x.Rating == request.GetListFeedbackIgnoreQueryFilterDto.Rating)
					&& (request.GetListFeedbackIgnoreQueryFilterDto.Comments == null || x.Comments.Contains(request.GetListFeedbackIgnoreQueryFilterDto.Comments))
					&& x.IsDeleted == request.GetListFeedbackIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListFeedbackIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListFeedbackIgnoreQueryFilterDto.SkipCount).Take(request.GetListFeedbackIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<FeedbackDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListFeedbackIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
