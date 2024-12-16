using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Products;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct
{
	public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListProductQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public GetListProductQueryHandler(IMapper mapper, IProductRepository productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		public async Task<GetListProductQueryResponse> Handle(GetListProductQuery request, CancellationToken cancellationToken)
		{
			var query = _productRepository.GetListAsNoTracking(
				x => (request.GetListProductDto.Name == null || x.Name.Contains(request.GetListProductDto.Name))
				&& (request.GetListProductDto.Description == null || x.Description.Contains(request.GetListProductDto.Description))
				&& (request.GetListProductDto.Price == null || x.Price == request.GetListProductDto.Price),
				includeProperties: request.GetListProductDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListProductDto.SortBy)
				.Skip(request.GetListProductDto.SkipCount).Take(request.GetListProductDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
			var result = _mapper.Map<List<ProductDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListProductQueryResponse(result, totalCount);
		}
	}
}
