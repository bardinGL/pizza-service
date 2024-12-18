using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter
{
	public class GetListOptionItemOrderItemIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOptionItemOrderItemIgnoreQueryFilterQuery, GetListOptionItemOrderItemIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemOrderItemRepository _optionitemorderitemRepository;

		public GetListOptionItemOrderItemIgnoreQueryFilterQueryHandler(IMapper mapper, IOptionItemOrderItemRepository optionitemorderitemRepository)
		{
			_mapper = mapper;
			_optionitemorderitemRepository = optionitemorderitemRepository;
		}

		public async Task<GetListOptionItemOrderItemIgnoreQueryFilterQueryResponse> Handle(GetListOptionItemOrderItemIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemorderitemRepository.GetListAsNoTracking(includeProperties: request.GetListOptionItemOrderItemIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListOptionItemOrderItemIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListOptionItemOrderItemIgnoreQueryFilterDto.Name))
					&& (request.GetListOptionItemOrderItemIgnoreQueryFilterDto.AdditionalPrice == null || x.AdditionalPrice == request.GetListOptionItemOrderItemIgnoreQueryFilterDto.AdditionalPrice)
					&& (request.GetListOptionItemOrderItemIgnoreQueryFilterDto.OptionItemId == null || x.OptionItemId == request.GetListOptionItemOrderItemIgnoreQueryFilterDto.OptionItemId)
					&& (request.GetListOptionItemOrderItemIgnoreQueryFilterDto.OrderItemId == null || x.OrderItemId == request.GetListOptionItemOrderItemIgnoreQueryFilterDto.OrderItemId)
					&& x.IsDeleted == request.GetListOptionItemOrderItemIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListOptionItemOrderItemIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListOptionItemOrderItemIgnoreQueryFilterDto.SkipCount).Take(request.GetListOptionItemOrderItemIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OptionItemOrderItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOptionItemOrderItemIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
