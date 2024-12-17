using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetOptionItemById
{
	public class GetOptionItemByIdQueryHandler : IRequestHandler<GetOptionItemByIdQuery, GetOptionItemByIdQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemRepository _optionitemRepository;

		public GetOptionItemByIdQueryHandler(IMapper mapper, IOptionItemRepository optionitemRepository)
		{
			_mapper = mapper;
			_optionitemRepository = optionitemRepository;
		}

		public async Task<GetOptionItemByIdQueryResponse> Handle(GetOptionItemByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _optionitemRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OptionItemDto>(entity);
			return new GetOptionItemByIdQueryResponse
			{
				OptionItem = result
			};
		}
	}
}
