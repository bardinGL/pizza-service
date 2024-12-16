using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Queries.GetListStaff
{
    public class GetListStaffQueryHandler : IRequestHandler<GetListStaffQuery, GetListStaffQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;

        public GetListStaffQueryHandler(IMapper mapper, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
        }

        public async Task<GetListStaffQueryResponse> Handle(GetListStaffQuery request, CancellationToken cancellationToken)
        {
            var query = _staffRepository.GetListAsNoTracking(
                x => (request.GetListStaffDto.Code == null || x.Code.Contains(request.GetListStaffDto.Code))
                && (request.GetListStaffDto.Name == null || x.Name.Contains(request.GetListStaffDto.Name))
                && (request.GetListStaffDto.Phone == null || x.Phone.Contains(request.GetListStaffDto.Phone))
                && (request.GetListStaffDto.Email == null || x.Email.Contains(request.GetListStaffDto.Email))
                && (request.GetListStaffDto.StaffType == null || x.StaffType == request.GetListStaffDto.StaffType)
                && (request.GetListStaffDto.Status == null || x.Status == request.GetListStaffDto.Status),
                includeProperties: request.GetListStaffDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListStaffDto.SortBy)
                .Skip(request.GetListStaffDto.SkipCount).Take(request.GetListStaffDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);
            var result = _mapper.Map<List<StaffDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffQueryResponse(result, totalCount);
        }
    }
}
