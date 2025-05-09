﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetZoneById
{
    public class GetZoneByIdQueryHandler : IRequestHandler<GetZoneByIdQuery, ZoneDto>
	{
		private readonly IMapper _mapper;
		private readonly IZoneRepository _zoneRepository;

		public GetZoneByIdQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
		{
			_mapper = mapper;
			_zoneRepository = zoneRepository;
		}

		public async Task<ZoneDto> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _zoneRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<ZoneDto>(entity);
			return result;
		}
	}
}
