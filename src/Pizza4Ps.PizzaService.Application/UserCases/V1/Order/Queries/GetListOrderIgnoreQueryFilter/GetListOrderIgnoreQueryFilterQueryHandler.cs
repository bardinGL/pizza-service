using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Queries.GetListOrderIgnoreQueryFilter
{
    public class GetListOrderIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOrderIgnoreQueryFilterQuery, GetListOrderIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetListOrderIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<GetListOrderIgnoreQueryFilterQueryResponse> Handle(GetListOrderIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _orderRepository.GetListAsNoTracking(includeProperties: request.GetListOrderIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.GetListOrderIgnoreQueryFilterDto.StartTime == null || x.StartTime == request.GetListOrderIgnoreQueryFilterDto.StartTime)
                    && (request.GetListOrderIgnoreQueryFilterDto.EndTime == null || x.EndTime == request.GetListOrderIgnoreQueryFilterDto.EndTime)
                    && (request.GetListOrderIgnoreQueryFilterDto.Status == null || x.Status.Contains(request.GetListOrderIgnoreQueryFilterDto.Status))
                    && x.IsDeleted == request.GetListOrderIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListOrderIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListOrderIgnoreQueryFilterDto.SkipCount).Take(request.GetListOrderIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<OrderDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListOrderIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
