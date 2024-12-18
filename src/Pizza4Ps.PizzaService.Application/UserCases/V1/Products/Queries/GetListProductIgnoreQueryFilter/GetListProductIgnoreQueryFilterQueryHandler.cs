using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Products;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProductIgnoreQueryFilter
{
	public class GetListProductIgnoreQueryFilterQueryHandler : IRequestHandler<GetListProductIgnoreQueryFilterQuery, GetListProductIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public GetListProductIgnoreQueryFilterQueryHandler(IMapper mapper, IProductRepository productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		public async Task<GetListProductIgnoreQueryFilterQueryResponse> Handle(GetListProductIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _productRepository.GetListAsNoTracking(includeProperties: request.GetListProductIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListProductIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListProductIgnoreQueryFilterDto.Name))
					&& (request.GetListProductIgnoreQueryFilterDto.Description == null || x.Description.Contains(request.GetListProductIgnoreQueryFilterDto.Description))
					&& (request.GetListProductIgnoreQueryFilterDto.Price == null || x.Price == request.GetListProductIgnoreQueryFilterDto.Price)
					&& (request.GetListProductIgnoreQueryFilterDto.CategoryId == null || x.CategoryId == request.GetListProductIgnoreQueryFilterDto.CategoryId)
					&& x.IsDeleted == request.GetListProductIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListProductIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListProductIgnoreQueryFilterDto.SkipCount).Take(request.GetListProductIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<ProductDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListProductIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
