using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneScheduleIgnoreQueryFilter
{
    public class GetListStaffZoneScheduleIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStaffZoneScheduleIgnoreQueryFilterQuery, GetListStaffZoneScheduleIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleRepository _StaffZoneScheduleRepository;

        public GetListStaffZoneScheduleIgnoreQueryFilterQueryHandler(IMapper mapper, IStaffZoneScheduleRepository StaffZoneScheduleRepository)
        {
            _mapper = mapper;
            _StaffZoneScheduleRepository = StaffZoneScheduleRepository;
        }

        public async Task<GetListStaffZoneScheduleIgnoreQueryFilterQueryResponse> Handle(GetListStaffZoneScheduleIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneScheduleRepository.GetListAsNoTracking(includeProperties: request.GetListStaffZoneScheduleIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.DayofWeek == null || x.DayofWeek == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.DayofWeek)
                && (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.ShiftStart == null || x.ShiftStart == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.ShiftStart)
                && (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.ShiftEnd == null || x.ShiftEnd == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.ShiftEnd)
                && (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.Note == null || x.Note == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.Note)
                && (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.StaffId == null || x.StaffId == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.StaffId)
                && (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.ZoneId == null || x.ZoneId == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.ZoneId)
                && (request.GetListStaffZoneScheduleIgnoreQueryFilterDto.WorkingTimeId == null || x.WorkingTimeId == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.WorkingTimeId)

                    && x.IsDeleted == request.GetListStaffZoneScheduleIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListStaffZoneScheduleIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListStaffZoneScheduleIgnoreQueryFilterDto.SkipCount).Take(request.GetListStaffZoneScheduleIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffZoneScheduleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffZoneScheduleIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
