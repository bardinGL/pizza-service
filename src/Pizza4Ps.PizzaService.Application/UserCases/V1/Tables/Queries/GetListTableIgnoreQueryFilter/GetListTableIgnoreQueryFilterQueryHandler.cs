using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTableIgnoreQueryFilter
{
	public class GetListTableIgnoreQueryFilterQueryHandler : IRequestHandler<GetListTableIgnoreQueryFilterQuery, GetListTableIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;

        public GetListTableIgnoreQueryFilterQueryHandler(IMapper mapper, ITableRepository tableRepository)
        {
            _mapper = mapper;
            _tableRepository = tableRepository;
        }

        public async Task<GetListTableIgnoreQueryFilterQueryResponse> Handle(GetListTableIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _tableRepository.GetListAsNoTracking(includeProperties: request.GetListTableIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.GetListTableIgnoreQueryFilterDto.TableNumber == null || x.TableNumber == request.GetListTableIgnoreQueryFilterDto.TableNumber)
                && (request.GetListTableIgnoreQueryFilterDto.Capacity == null || x.Capacity == request.GetListTableIgnoreQueryFilterDto.Capacity)
                && (request.GetListTableIgnoreQueryFilterDto.Status == null || x.Status == request.GetListTableIgnoreQueryFilterDto.Status)
                && (request.GetListTableIgnoreQueryFilterDto.ZoneId == null || x.ZoneId == request.GetListTableIgnoreQueryFilterDto.ZoneId)
                    && x.IsDeleted == request.GetListTableIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListTableIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListTableIgnoreQueryFilterDto.SkipCount).Take(request.GetListTableIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<TableDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListTableIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
