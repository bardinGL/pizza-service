using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Queries.GetListStaffIgnoreQueryFilter
{
    public class GetListStaffIgnoreQueryFilterQueryHandler : IRequestHandler<GetListStaffIgnoreQueryFilterQuery, GetListStaffIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;

        public GetListStaffIgnoreQueryFilterQueryHandler(IMapper mapper, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
        }

        public async Task<GetListStaffIgnoreQueryFilterQueryResponse> Handle(GetListStaffIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _staffRepository.GetListAsNoTracking(includeProperties: request.GetListStaffIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListStaffIgnoreQueryFilterDto.Code == null || x.Code.Contains(request.GetListStaffIgnoreQueryFilterDto.Code))
                    && (request.GetListStaffIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListStaffIgnoreQueryFilterDto.Name))
                    && (request.GetListStaffIgnoreQueryFilterDto.Phone == null || x.Phone.Contains(request.GetListStaffIgnoreQueryFilterDto.Phone))
                    && (request.GetListStaffIgnoreQueryFilterDto.Email == null || x.Email.Contains(request.GetListStaffIgnoreQueryFilterDto.Email))
                    && (request.GetListStaffIgnoreQueryFilterDto.StaffType == null || x.StaffType == request.GetListStaffIgnoreQueryFilterDto.StaffType)
                    && (request.GetListStaffIgnoreQueryFilterDto.Status == null || x.Status == request.GetListStaffIgnoreQueryFilterDto.Status)
                    && x.IsDeleted == request.GetListStaffIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListStaffIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListStaffIgnoreQueryFilterDto.SkipCount).Take(request.GetListStaffIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListStaffIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
