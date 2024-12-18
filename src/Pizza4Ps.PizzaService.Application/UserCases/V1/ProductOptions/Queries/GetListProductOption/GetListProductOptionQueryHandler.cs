using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetListProductOption
{
	public class GetListProductQueryHandler : IRequestHandler<GetListProductOptionQuery, GetListProductOptionQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductOptionRepository _productOptionRepository;

		public GetListProductQueryHandler(IMapper mapper, IProductOptionRepository productOptionRepository)
		{
			_mapper = mapper;
			_productOptionRepository = productOptionRepository;
		}

		public async Task<GetListProductOptionQueryResponse> Handle(GetListProductOptionQuery request, CancellationToken cancellationToken)
		{
			var query = _productOptionRepository.GetListAsNoTracking(
				x => (request.GetListProductOptionDto.ProductId == null || x.ProductId == request.GetListProductOptionDto.ProductId)
				&& (request.GetListProductOptionDto.OptionId == null || x.OptionId == request.GetListProductOptionDto.OptionId),
				includeProperties: request.GetListProductOptionDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListProductOptionDto.SortBy)
				.Skip(request.GetListProductOptionDto.SkipCount).Take(request.GetListProductOptionDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.ProductOptionErrorConstant.PRODUCTOPTION_NOT_FOUND);
			var result = _mapper.Map<List<ProductOptionDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListProductOptionQueryResponse(result, totalCount);
		}
	}
}
