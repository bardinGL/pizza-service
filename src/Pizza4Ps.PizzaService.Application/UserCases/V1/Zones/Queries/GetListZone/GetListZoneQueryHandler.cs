using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Zones;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZone
{
    public class GetListZoneQueryHandler : IRequestHandler<GetListZoneQuery, GetListZoneQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IZoneRepository _zoneRepository;

        public GetListZoneQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
        }

        public async Task<GetListZoneQueryResponse> Handle(GetListZoneQuery request, CancellationToken cancellationToken)
        {
            var query = _zoneRepository.GetListAsNoTracking(
                x => (request.GetListZoneDto.Name == null || x.Name.Contains(request.GetListZoneDto.Name))
                && (request.GetListZoneDto.Capacity == null || x.Capacity == request.GetListZoneDto.Capacity)
                && (request.GetListZoneDto.Description == null || x.Description.Contains(request.GetListZoneDto.Description))
                && (request.GetListZoneDto.Status == null || x.Status == request.GetListZoneDto.Status),
                includeProperties: request.GetListZoneDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListZoneDto.SortBy)
                .Skip(request.GetListZoneDto.SkipCount).Take(request.GetListZoneDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);
            var result = _mapper.Map<List<ZoneDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListZoneQueryResponse(result, totalCount);
        }
    }
}
