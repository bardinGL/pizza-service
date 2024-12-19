using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem
{
	public class GetListOptionItemQueryHandler : IRequestHandler<GetListOptionItemQuery, GetListOptionItemQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemRepository _optionitemRepository;

		public GetListOptionItemQueryHandler(IMapper mapper, IOptionItemRepository optionitemRepository)
		{
			_mapper = mapper;
			_optionitemRepository = optionitemRepository;
		}

		public async Task<GetListOptionItemQueryResponse> Handle(GetListOptionItemQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemRepository.GetListAsNoTracking(
				x => (request.GetListOptionItemDto.Name == null || x.Name.Contains(request.GetListOptionItemDto.Name))
				&& (request.GetListOptionItemDto.AdditionalPrice == null || x.AdditionalPrice == request.GetListOptionItemDto.AdditionalPrice)
				&& (request.GetListOptionItemDto.OptionId == null || x.OptionId == request.GetListOptionItemDto.OptionId),
				includeProperties: request.GetListOptionItemDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListOptionItemDto.SortBy)
				.Skip(request.GetListOptionItemDto.SkipCount).Take(request.GetListOptionItemDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OptionItemErrorConstant.OPTIONITEM_NOT_FOUND);
			var result = _mapper.Map<List<OptionItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOptionItemQueryResponse(result, totalCount);
		}
	}
}
