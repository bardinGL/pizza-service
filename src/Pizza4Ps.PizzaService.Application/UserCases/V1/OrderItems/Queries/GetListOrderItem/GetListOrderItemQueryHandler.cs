using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem
{
	public class GetListOrderItemQueryHandler : IRequestHandler<GetListOrderItemQuery, GetListOrderItemQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemRepository _orderitemRepository;

		public GetListOrderItemQueryHandler(IMapper mapper, IOrderItemRepository orderitemRepository)
		{
			_mapper = mapper;
			_orderitemRepository = orderitemRepository;
		}

		public async Task<GetListOrderItemQueryResponse> Handle(GetListOrderItemQuery request, CancellationToken cancellationToken)
		{
			var query = _orderitemRepository.GetListAsNoTracking(
				x => (request.GetListOrderItemDto.Name == null || x.Name.Contains(request.GetListOrderItemDto.Name))
				&& (request.GetListOrderItemDto.Quantity == null || x.Quantity == request.GetListOrderItemDto.Quantity)
				&& (request.GetListOrderItemDto.Price == null || x.Price == request.GetListOrderItemDto.Price)
				&& (request.GetListOrderItemDto.OrderId == null || x.OrderId == request.GetListOrderItemDto.OrderId)
				&& (request.GetListOrderItemDto.ProductId == null || x.ProductId == request.GetListOrderItemDto.ProductId),
				includeProperties: request.GetListOrderItemDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListOrderItemDto.SortBy)
				.Skip(request.GetListOrderItemDto.SkipCount).Take(request.GetListOrderItemDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.ORDERITEM_NOT_FOUND);
			var result = _mapper.Map<List<OrderItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOrderItemQueryResponse(result, totalCount);
		}
	}
}
