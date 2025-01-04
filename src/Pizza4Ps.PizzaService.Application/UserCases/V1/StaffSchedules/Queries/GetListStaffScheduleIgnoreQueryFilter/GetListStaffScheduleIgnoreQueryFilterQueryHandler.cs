using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffScheduleIgnoreQueryFilter
{
    public class GetListStaffScheduleIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStaffScheduleIgnoreQueryFilterQuery, GetListStaffScheduleIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffScheduleRepository _StaffScheduleRepository;

        public GetListStaffScheduleIgnoreQueryFilterQueryHandler(IMapper mapper, IStaffScheduleRepository StaffScheduleRepository)
        {
            _mapper = mapper;
            _StaffScheduleRepository = StaffScheduleRepository;
        }

        public async Task<GetListStaffScheduleIgnoreQueryFilterQueryResponse> Handle(GetListStaffScheduleIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffScheduleRepository.GetListAsNoTracking(includeProperties: request.GetListStaffScheduleIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                    .Where(
                    x => (request.GetListStaffScheduleIgnoreQueryFilterDto.SchedualDate == null || x.SchedualDate == request.GetListStaffScheduleIgnoreQueryFilterDto.SchedualDate)
                    && (request.GetListStaffScheduleIgnoreQueryFilterDto.ShiftStart == null || x.ShiftStart == request.GetListStaffScheduleIgnoreQueryFilterDto.ShiftStart)
                    && (request.GetListStaffScheduleIgnoreQueryFilterDto.ShiftEnd == null || x.ShiftEnd == request.GetListStaffScheduleIgnoreQueryFilterDto.ShiftEnd)
                    && (request.GetListStaffScheduleIgnoreQueryFilterDto.Status == null || x.Status == request.GetListStaffScheduleIgnoreQueryFilterDto.Status)
                    && (request.GetListStaffScheduleIgnoreQueryFilterDto.StaffId == null || x.StaffId == request.GetListStaffScheduleIgnoreQueryFilterDto.StaffId)
                    && (request.GetListStaffScheduleIgnoreQueryFilterDto.ZoneId == null || x.ZoneId == request.GetListStaffScheduleIgnoreQueryFilterDto.ZoneId)
                    && x.IsDeleted == request.GetListStaffScheduleIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListStaffScheduleIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListStaffScheduleIgnoreQueryFilterDto.SkipCount).Take(request.GetListStaffScheduleIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffScheduleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffScheduleIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}

