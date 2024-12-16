using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetZoneById
{
	public class GetZoneByIdQueryHandler : IRequestHandler<GetZoneByIdQuery, GetZoneByIdQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IZoneRepository _zoneRepository;

		public GetZoneByIdQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
		{
			_mapper = mapper;
			_zoneRepository = zoneRepository;
		}

		public async Task<GetZoneByIdQueryResponse> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _zoneRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<ZoneDto>(entity);
			return new GetZoneByIdQueryResponse
			{
				Zone = result
			};
		}
	}
}
