using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable
{
    public class GetListTableQueryHandler : IRequestHandler<GetListTableQuery, GetListTableQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;

        public GetListTableQueryHandler(IMapper mapper, ITableRepository tableRepository)
        {
            _mapper = mapper;
            _tableRepository = tableRepository;
        }

        public async Task<GetListTableQueryResponse> Handle(GetListTableQuery request, CancellationToken cancellationToken)
        {
            var query = _tableRepository.GetListAsNoTracking(
                x => (request.GetListTableDto.TableNumber == null || x.TableNumber == request.GetListTableDto.TableNumber)
                && (request.GetListTableDto.Capacity == null || x.Capacity == request.GetListTableDto.Capacity)
                && (request.GetListTableDto.Status == null || x.Status == request.GetListTableDto.Status)
                && (request.GetListTableDto.ZoneId == null || x.ZoneId == request.GetListTableDto.ZoneId)
                , includeProperties: request.GetListTableDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListTableDto.SortBy)
                .Skip(request.GetListTableDto.SkipCount).Take(request.GetListTableDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            var result = _mapper.Map<List<TableDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListTableQueryResponse(result, totalCount);
        }
    }
}
