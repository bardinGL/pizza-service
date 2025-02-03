﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetWorkingTimeById
{
    public class GetWorkingTimeByIdQueryHandler : IRequestHandler<GetWorkingTimeByIdQuery, WorkingTimeDto>
	{
		private readonly IMapper _mapper;
		private readonly IWorkingTimeRepository _workingtimeRepository;

		public GetWorkingTimeByIdQueryHandler(IMapper mapper, IWorkingTimeRepository workingtimeRepository)
		{
			_mapper = mapper;
			_workingtimeRepository = workingtimeRepository;
		}

		public async Task<WorkingTimeDto> Handle(GetWorkingTimeByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _workingtimeRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<WorkingTimeDto>(entity);
			return result;
		}
	}
}
