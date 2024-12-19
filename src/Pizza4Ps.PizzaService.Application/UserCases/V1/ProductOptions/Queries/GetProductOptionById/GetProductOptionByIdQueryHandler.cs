using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductOptions.Queries.GetProductOptionById
{
	public class GetProductOptionByIdQueryHandler : IRequestHandler<GetProductOptionByIdQuery, GetProductOptionByIdQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IProductOptionRepository _ProductOptionRepository;

		public GetProductOptionByIdQueryHandler(IMapper mapper, IProductOptionRepository ProductOptionRepository)
		{
			_mapper = mapper;
			_ProductOptionRepository = ProductOptionRepository;
		}

		public async Task<GetProductOptionByIdQueryResponse> Handle(GetProductOptionByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _ProductOptionRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<ProductOptionDto>(entity);
			return new GetProductOptionByIdQueryResponse
			{
				ProductOption = result
			};
		}
	}
}
