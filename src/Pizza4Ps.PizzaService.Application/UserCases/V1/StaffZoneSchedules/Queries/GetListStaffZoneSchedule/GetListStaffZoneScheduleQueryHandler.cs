using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZoneSchedules.Queries.GetListStaffZoneSchedule
{
    public class GetListStaffZoneScheduleQueryHandler : IRequestHandler<GetListStaffZoneScheduleQuery, GetListStaffZoneScheduleQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneScheduleRepository _StaffZoneScheduleRepository;

        public GetListStaffZoneScheduleQueryHandler(IMapper mapper, IStaffZoneScheduleRepository StaffZoneScheduleRepository)
        {
            _mapper = mapper;
            _StaffZoneScheduleRepository = StaffZoneScheduleRepository;
        }

        public async Task<GetListStaffZoneScheduleQueryResponse> Handle(GetListStaffZoneScheduleQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneScheduleRepository.GetListAsNoTracking(
                x => (request.GetListStaffZoneScheduleDto.DayofWeek == null || x.DayofWeek == request.GetListStaffZoneScheduleDto.DayofWeek)
                && (request.GetListStaffZoneScheduleDto.ShiftStart == null || x.ShiftStart == request.GetListStaffZoneScheduleDto.ShiftStart)
                && (request.GetListStaffZoneScheduleDto.ShiftEnd == null || x.ShiftEnd == request.GetListStaffZoneScheduleDto.ShiftEnd)
                && (request.GetListStaffZoneScheduleDto.Note == null || x.Note == request.GetListStaffZoneScheduleDto.Note)
                && (request.GetListStaffZoneScheduleDto.StaffId == null || x.StaffId == request.GetListStaffZoneScheduleDto.StaffId)
                && (request.GetListStaffZoneScheduleDto.ZoneId == null || x.ZoneId == request.GetListStaffZoneScheduleDto.ZoneId)
                && (request.GetListStaffZoneScheduleDto.WorkingTimeId == null || x.WorkingTimeId == request.GetListStaffZoneScheduleDto.WorkingTimeId)

                ,
                includeProperties: request.GetListStaffZoneScheduleDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListStaffZoneScheduleDto.SortBy)
                .Skip(request.GetListStaffZoneScheduleDto.SkipCount).Take(request.GetListStaffZoneScheduleDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StaffZoneScheduleErrorConstant.STAFFZONESCHEDULE_NOT_FOUND);
            var result = _mapper.Map<List<StaffZoneScheduleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffZoneScheduleQueryResponse(result, totalCount);
        }
    }
}
