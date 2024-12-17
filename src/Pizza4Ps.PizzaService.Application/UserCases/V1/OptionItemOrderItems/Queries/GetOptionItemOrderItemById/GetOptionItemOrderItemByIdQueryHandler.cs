using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById
{
	public class GetOptionItemOrderItemByIdQueryHandler : IRequestHandler<GetOptionItemOrderItemByIdQuery, GetOptionItemOrderItemByIdQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemOrderItemRepository _optionitemorderitemRepository;

		public GetOptionItemOrderItemByIdQueryHandler(IMapper mapper, IOptionItemOrderItemRepository optionitemorderitemRepository)
		{
			_mapper = mapper;
			_optionitemorderitemRepository = optionitemorderitemRepository;
		}

		public async Task<GetOptionItemOrderItemByIdQueryResponse> Handle(GetOptionItemOrderItemByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _optionitemorderitemRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<OptionItemOrderItemDto>(entity);
			return new GetOptionItemOrderItemByIdQueryResponse
			{
				OptionItemOrderItem = result
			};
		}
	}
}
