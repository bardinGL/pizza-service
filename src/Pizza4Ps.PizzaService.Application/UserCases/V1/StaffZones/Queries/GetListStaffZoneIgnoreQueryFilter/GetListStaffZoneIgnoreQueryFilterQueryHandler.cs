using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZoneIgnoreQueryFilter
{
    public class GetListStaffZoneIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStaffZoneIgnoreQueryFilterQuery, GetListStaffZoneIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneRepository _StaffZoneRepository;

        public GetListStaffZoneIgnoreQueryFilterQueryHandler(IMapper mapper, IStaffZoneRepository StaffZoneRepository)
        {
            _mapper = mapper;
            _StaffZoneRepository = StaffZoneRepository;
        }

        public async Task<GetListStaffZoneIgnoreQueryFilterQueryResponse> Handle(GetListStaffZoneIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneRepository.GetListAsNoTracking(includeProperties: request.GetListStaffZoneIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.GetListStaffZoneIgnoreQueryFilterDto.ShiftStart == null || x.ShiftStart == request.GetListStaffZoneIgnoreQueryFilterDto.ShiftStart)
                && (request.GetListStaffZoneIgnoreQueryFilterDto.ShiftEnd == null || x.ShiftEnd == request.GetListStaffZoneIgnoreQueryFilterDto.ShiftEnd)
                && (request.GetListStaffZoneIgnoreQueryFilterDto.Note == null || x.Note == request.GetListStaffZoneIgnoreQueryFilterDto.Note)
                && (request.GetListStaffZoneIgnoreQueryFilterDto.StaffId == null || x.StaffId == request.GetListStaffZoneIgnoreQueryFilterDto.StaffId)
                && (request.GetListStaffZoneIgnoreQueryFilterDto.ZoneId == null || x.ZoneId == request.GetListStaffZoneIgnoreQueryFilterDto.ZoneId)
                && x.IsDeleted == request.GetListStaffZoneIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListStaffZoneIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListStaffZoneIgnoreQueryFilterDto.SkipCount).Take(request.GetListStaffZoneIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffZoneDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffZoneIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
