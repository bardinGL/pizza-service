using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem
{
	public class GetListOptionItemOrderItemQueryHandler : IRequestHandler<GetListOptionItemOrderItemQuery, GetListOptionItemOrderItemQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemOrderItemRepository _optionitemorderitemRepository;

		public GetListOptionItemOrderItemQueryHandler(IMapper mapper, IOptionItemOrderItemRepository optionitemorderitemRepository)
		{
			_mapper = mapper;
			_optionitemorderitemRepository = optionitemorderitemRepository;
		}

		public async Task<GetListOptionItemOrderItemQueryResponse> Handle(GetListOptionItemOrderItemQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemorderitemRepository.GetListAsNoTracking(
				x => (request.GetListOptionItemOrderItemDto.Name == null || x.Name.Contains(request.GetListOptionItemOrderItemDto.Name))
				&& (request.GetListOptionItemOrderItemDto.AdditionalPrice == null || x.AdditionalPrice == request.GetListOptionItemOrderItemDto.AdditionalPrice)
				&& (request.GetListOptionItemOrderItemDto.OptionItemId == null || x.OptionItemId == request.GetListOptionItemOrderItemDto.OptionItemId)
				&& (request.GetListOptionItemOrderItemDto.OrderItemId == null || x.OrderItemId == request.GetListOptionItemOrderItemDto.OrderItemId),
				includeProperties: request.GetListOptionItemOrderItemDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListOptionItemOrderItemDto.SortBy)
				.Skip(request.GetListOptionItemOrderItemDto.SkipCount).Take(request.GetListOptionItemOrderItemDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OptionItemOrderItemErrorConstant.OPTIONITEMORDERITEM_NOT_FOUND);
			var result = _mapper.Map<List<OptionItemOrderItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOptionItemOrderItemQueryResponse(result, totalCount);
		}
	}
}
