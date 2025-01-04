using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZone
{
    public class GetListStaffZoneQueryHandler : IRequestHandler<GetListStaffZoneQuery, GetListStaffZoneQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneRepository _StaffZoneRepository;

        public GetListStaffZoneQueryHandler(IMapper mapper, IStaffZoneRepository StaffZoneRepository)
        {
            _mapper = mapper;
            _StaffZoneRepository = StaffZoneRepository;
        }

        public async Task<GetListStaffZoneQueryResponse> Handle(GetListStaffZoneQuery request, CancellationToken cancellationToken)
        {
            var query = _StaffZoneRepository.GetListAsNoTracking(
                x => (request.GetListStaffZoneDto.ShiftStart == null || x.ShiftStart == request.GetListStaffZoneDto.ShiftStart)
                && (request.GetListStaffZoneDto.ShiftEnd == null || x.ShiftEnd == request.GetListStaffZoneDto.ShiftEnd)
                && (request.GetListStaffZoneDto.Note == null || x.Note == request.GetListStaffZoneDto.Note)
                && (request.GetListStaffZoneDto.StaffId == null || x.StaffId == request.GetListStaffZoneDto.StaffId)
                && (request.GetListStaffZoneDto.ZoneId == null || x.ZoneId == request.GetListStaffZoneDto.ZoneId),
                includeProperties: request.GetListStaffZoneDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListStaffZoneDto.SortBy)
                .Skip(request.GetListStaffZoneDto.SkipCount).Take(request.GetListStaffZoneDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StaffZoneErrorConstant.STAFFZONE_NOT_FOUND);
            var result = _mapper.Map<List<StaffZoneDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffZoneQueryResponse(result, totalCount);
        }
    }
}
