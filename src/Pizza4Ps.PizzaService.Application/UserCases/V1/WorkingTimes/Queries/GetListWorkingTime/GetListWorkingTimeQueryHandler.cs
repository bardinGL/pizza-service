using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTime
{
	public class GetListWorkingTimeQueryHandler : IRequestHandler<GetListWorkingTimeQuery, GetListWorkingTimeQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IWorkingTimeRepository _workingtimeRepository;

		public GetListWorkingTimeQueryHandler(IMapper mapper, IWorkingTimeRepository workingtimeRepository)
		{
			_mapper = mapper;
			_workingtimeRepository = workingtimeRepository;
		}

		public async Task<GetListWorkingTimeQueryResponse> Handle(GetListWorkingTimeQuery request, CancellationToken cancellationToken)
		{
			var query = _workingtimeRepository.GetListAsNoTracking(
				x => (request.GetListWorkingTimeDto.DayOfWeek == null || x.DayOfWeek == request.GetListWorkingTimeDto.DayOfWeek)
				&& (request.GetListWorkingTimeDto.ShiftCode == null || x.ShiftCode.Contains(request.GetListWorkingTimeDto.ShiftCode))
				&& (request.GetListWorkingTimeDto.Name == null || x.Name.Contains(request.GetListWorkingTimeDto.Name))
				&& (request.GetListWorkingTimeDto.StartTime == null || x.StartTime == request.GetListWorkingTimeDto.StartTime)
				&& (request.GetListWorkingTimeDto.EndTime == null || x.EndTime == request.GetListWorkingTimeDto.EndTime),
				includeProperties: request.GetListWorkingTimeDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListWorkingTimeDto.SortBy)
				.Skip(request.GetListWorkingTimeDto.SkipCount).Take(request.GetListWorkingTimeDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.WorkingTimeErrorConstant.WORKINGTIME_NOT_FOUND);
			var result = _mapper.Map<List<WorkingTimeDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListWorkingTimeQueryResponse(result, totalCount);
		}
	}
}
