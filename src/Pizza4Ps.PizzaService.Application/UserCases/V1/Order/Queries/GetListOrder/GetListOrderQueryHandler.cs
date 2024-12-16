using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Orders;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Order.Queries.GetListOrder
{
    public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, GetListOrderQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetListOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<GetListOrderQueryResponse> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
        {
            var query = _orderRepository.GetListAsNoTracking(
                x => (request.GetListOrderDto.StartTime == null || x.StartTime == request.GetListOrderDto.StartTime)
                && (request.GetListOrderDto.EndTime == null || x.EndTime == request.GetListOrderDto.EndTime)
                && (request.GetListOrderDto.Status == null || x.Status.Contains(request.GetListOrderDto.Status)),
                includeProperties: request.GetListOrderDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListOrderDto.SortBy)
                .Skip(request.GetListOrderDto.SkipCount).Take(request.GetListOrderDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.OrderErrorConstant.ORDER_NOT_FOUND);
            var result = _mapper.Map<List<OrderDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListOrderQueryResponse(result, totalCount);
        }
    }
}
