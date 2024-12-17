using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem
{
	public class CreateOptionItemOrderItemCommandHandler : IRequestHandler<CreateOptionItemOrderItemCommand, CreateOptionItemOrderItemCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemOrderItemService _optionitemorderitemService;

		public CreateOptionItemOrderItemCommandHandler(IMapper mapper, IOptionItemOrderItemService optionitemorderitemService)
		{
			_mapper = mapper;
			_optionitemorderitemService = optionitemorderitemService;
		}

		public async Task<CreateOptionItemOrderItemCommandResponse> Handle(CreateOptionItemOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemorderitemService.CreateAsync(
				request.CreateOptionItemOrderItemDto.Name,
				request.CreateOptionItemOrderItemDto.AdditionalPrice,
				request.CreateOptionItemOrderItemDto.OptionItemId,
				request.CreateOptionItemOrderItemDto.OrderItemId);
			return new CreateOptionItemOrderItemCommandResponse
			{
				Id = result
			};
		}
	}
}
