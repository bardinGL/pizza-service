using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem
{
	public class UpdateOptionItemOrderItemCommandHandler : IRequestHandler<UpdateOptionItemOrderItemCommand, UpdateOptionItemOrderItemCommandResponse>
	{
		private readonly IOptionItemOrderItemService _optionitemorderitemService;

		public UpdateOptionItemOrderItemCommandHandler(IOptionItemOrderItemService optionitemorderitemService)
		{
			_optionitemorderitemService = optionitemorderitemService;
		}

		public async Task<UpdateOptionItemOrderItemCommandResponse> Handle(UpdateOptionItemOrderItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemorderitemService.UpdateAsync(
				request.Id,
				request.UpdateOptionItemOrderItemDto.Name,
				request.UpdateOptionItemOrderItemDto.AdditionalPrice,
				request.UpdateOptionItemOrderItemDto.OptionItemId,
				request.UpdateOptionItemOrderItemDto.OrderItemId);
			return new UpdateOptionItemOrderItemCommandResponse
			{
				Id = result
			};
		}
	}
}
