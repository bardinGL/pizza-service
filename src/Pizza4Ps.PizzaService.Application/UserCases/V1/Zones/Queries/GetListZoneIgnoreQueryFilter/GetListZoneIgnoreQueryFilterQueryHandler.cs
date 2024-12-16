using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZoneIgnoreQueryFilter
{
	public class GetListZoneIgnoreQueryFilterQueryHandler : IRequestHandler<GetListZoneIgnoreQueryFilterQuery, GetListZoneIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IZoneRepository _zoneRepository;

		public GetListZoneIgnoreQueryFilterQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
		{
			_mapper = mapper;
			_zoneRepository = zoneRepository;
		}

		public async Task<GetListZoneIgnoreQueryFilterQueryResponse> Handle(GetListZoneIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _zoneRepository.GetListAsNoTracking(includeProperties: request.GetListZoneIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListZoneIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListZoneIgnoreQueryFilterDto.Name))
					&& (request.GetListZoneIgnoreQueryFilterDto.Capacity == null || x.Capacity == request.GetListZoneIgnoreQueryFilterDto.Capacity)
					&& (request.GetListZoneIgnoreQueryFilterDto.Description == null || x.Description.Contains(request.GetListZoneIgnoreQueryFilterDto.Description))
					&& (request.GetListZoneIgnoreQueryFilterDto.Status == null || x.Status == request.GetListZoneIgnoreQueryFilterDto.Status)
					&& x.IsDeleted == request.GetListZoneIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListZoneIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListZoneIgnoreQueryFilterDto.SkipCount).Take(request.GetListZoneIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<ZoneDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListZoneIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
