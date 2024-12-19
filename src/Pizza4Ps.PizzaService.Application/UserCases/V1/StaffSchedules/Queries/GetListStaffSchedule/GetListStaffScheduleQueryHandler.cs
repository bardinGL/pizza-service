using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffSchedule;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffSchedule
{
    public class GetListStaffScheduleQueryHandler : IRequestHandler<GetListStaffScheduleQuery, GetListStaffScheduleQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffScheduleRepository _StaffScheduleRepository;

        public GetListStaffScheduleQueryHandler(IMapper mapper, IStaffScheduleRepository StaffScheduleRepository)
        {
            _mapper = mapper;
            _StaffScheduleRepository = StaffScheduleRepository;
        }

        public async Task<GetListStaffScheduleQueryResponse> Handle(GetListStaffScheduleQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffScheduleRepository.GetListAsNoTracking(
                x => (request.GetListStaffScheduleDto.SchedualDate == null || x.SchedualDate == request.GetListStaffScheduleDto.SchedualDate)
                && (request.GetListStaffScheduleDto.ShiftStart == null || x.ShiftStart == request.GetListStaffScheduleDto.ShiftStart)
                && (request.GetListStaffScheduleDto.ShiftEnd == null || x.ShiftEnd == request.GetListStaffScheduleDto.ShiftEnd)
                && (request.GetListStaffScheduleDto.Status == null || x.Status == request.GetListStaffScheduleDto.Status)
                && (request.GetListStaffScheduleDto.StaffId == null || x.StaffId == request.GetListStaffScheduleDto.StaffId)
                && (request.GetListStaffScheduleDto.ZoneId == null || x.ZoneId == request.GetListStaffScheduleDto.ZoneId)
                ,
                includeProperties: request.GetListStaffScheduleDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListStaffScheduleDto.SortBy)
                .Skip(request.GetListStaffScheduleDto.SkipCount).Take(request.GetListStaffScheduleDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StaffScheduleErrorConstant.STAFFSCHEDULE_NOT_FOUND);
            var result = _mapper.Map<List<StaffScheduleDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffScheduleQueryResponse(result, totalCount);
        }
    }
}
