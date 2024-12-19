using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTimeIgnoreQueryFilter
{
	public class GetListWorkingTimeIgnoreQueryFilterQueryHandler : IRequestHandler<GetListWorkingTimeIgnoreQueryFilterQuery, GetListWorkingTimeIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IWorkingTimeRepository _workingtimeRepository;

		public GetListWorkingTimeIgnoreQueryFilterQueryHandler(IMapper mapper, IWorkingTimeRepository workingtimeRepository)
		{
			_mapper = mapper;
			_workingtimeRepository = workingtimeRepository;
		}

		public async Task<GetListWorkingTimeIgnoreQueryFilterQueryResponse> Handle(GetListWorkingTimeIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _workingtimeRepository.GetListAsNoTracking(includeProperties: request.GetListWorkingTimeIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListWorkingTimeIgnoreQueryFilterDto.DayOfWeek == null || x.DayOfWeek == request.GetListWorkingTimeIgnoreQueryFilterDto.DayOfWeek)
					&& (request.GetListWorkingTimeIgnoreQueryFilterDto.ShiftCode == null || x.ShiftCode.Contains(request.GetListWorkingTimeIgnoreQueryFilterDto.ShiftCode))
					&& (request.GetListWorkingTimeIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListWorkingTimeIgnoreQueryFilterDto.Name))
					&& (request.GetListWorkingTimeIgnoreQueryFilterDto.StartTime == null || x.StartTime == request.GetListWorkingTimeIgnoreQueryFilterDto.StartTime)
					&& (request.GetListWorkingTimeIgnoreQueryFilterDto.EndTime == null || x.EndTime == request.GetListWorkingTimeIgnoreQueryFilterDto.EndTime)
					&& x.IsDeleted == request.GetListWorkingTimeIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListWorkingTimeIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListWorkingTimeIgnoreQueryFilterDto.SkipCount).Take(request.GetListWorkingTimeIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<WorkingTimeDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListWorkingTimeIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
