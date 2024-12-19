using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItemIgnoreQueryFilter
{
	public class GetListOptionItemIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOptionItemIgnoreQueryFilterQuery, GetListOptionItemIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemRepository _optionitemRepository;

		public GetListOptionItemIgnoreQueryFilterQueryHandler(IMapper mapper, IOptionItemRepository optionitemRepository)
		{
			_mapper = mapper;
			_optionitemRepository = optionitemRepository;
		}

		public async Task<GetListOptionItemIgnoreQueryFilterQueryResponse> Handle(GetListOptionItemIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _optionitemRepository.GetListAsNoTracking(includeProperties: request.GetListOptionItemIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListOptionItemIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListOptionItemIgnoreQueryFilterDto.Name))
					&& (request.GetListOptionItemIgnoreQueryFilterDto.AdditionalPrice == null || x.AdditionalPrice == request.GetListOptionItemIgnoreQueryFilterDto.AdditionalPrice)
					&& (request.GetListOptionItemIgnoreQueryFilterDto.OptionId == null || x.OptionId == request.GetListOptionItemIgnoreQueryFilterDto.OptionId)
					&& x.IsDeleted == request.GetListOptionItemIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListOptionItemIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListOptionItemIgnoreQueryFilterDto.SkipCount).Take(request.GetListOptionItemIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OptionItemDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOptionItemIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
