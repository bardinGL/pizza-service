using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter
{
	public class GetListOrderItemIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOrderItemIgnoreQueryFilterQuery, GetListOrderItemIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderItemRepository _orderitemRepository;

		public GetListOrderItemIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderItemRepository orderitemRepository)
		{
			_mapper = mapper;
			_orderitemRepository = orderitemRepository;
		}

		public async Task<GetListOrderItemIgnoreQueryFilterQueryResponse> Handle(GetListOrderItemIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _orderitemRepository.GetListAsNoTracking(includeProperties: request.GetListOrderItemIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListOrderItemIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListOrderItemIgnoreQueryFilterDto.Name))
					&& (request.GetListOrderItemIgnoreQueryFilterDto.Quantity == null || x.Quantity == request.GetListOrderItemIgnoreQueryFilterDto.Quantity)
					&& (request.GetListOrderItemIgnoreQueryFilterDto.Price == null || x.Price == request.GetListOrderItemIgnoreQueryFilterDto.Price)
					&& (request.GetListOrderItemIgnoreQueryFilterDto.OrderId == null || x.OrderId == request.GetListOrderItemIgnoreQueryFilterDto.OrderId)
					&& (request.GetListOrderItemIgnoreQueryFilterDto.ProductId == null || x.ProductId == request.GetListOrderItemIgnoreQueryFilterDto.ProductId)
					&& x.IsDeleted == request.GetListOrderItemIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListOrderItemIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListOrderItemIgnoreQueryFilterDto.SkipCount).Take(request.GetListOrderItemIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOrderItemIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
