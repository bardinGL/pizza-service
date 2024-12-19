using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOptionIgnoreQueryFilter
{
	public class GetListProductOptionIgnoreQueryFilterQueryHandler : IRequestHandler<GetListProductOptionIgnoreQueryFilterQuery, GetListProductOptionIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductOptionRepository _ProductOptionRepository;

		public GetListProductOptionIgnoreQueryFilterQueryHandler(IMapper mapper, IProductOptionRepository ProductOptionRepository)
		{
			_mapper = mapper;
			_ProductOptionRepository = ProductOptionRepository;
		}

		public async Task<GetListProductOptionIgnoreQueryFilterQueryResponse> Handle(GetListProductOptionIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _ProductOptionRepository.GetListAsNoTracking(includeProperties: request.GetListProductOptionIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListProductOptionIgnoreQueryFilterDto.ProductId == null || x.ProductId == request.GetListProductOptionIgnoreQueryFilterDto.ProductId)
					&& (request.GetListProductOptionIgnoreQueryFilterDto.OptionId == null || x.OptionId == request.GetListProductOptionIgnoreQueryFilterDto.OptionId)
					&& x.IsDeleted == request.GetListProductOptionIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListProductOptionIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListProductOptionIgnoreQueryFilterDto.SkipCount).Take(request.GetListProductOptionIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<ProductOptionDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListProductOptionIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
