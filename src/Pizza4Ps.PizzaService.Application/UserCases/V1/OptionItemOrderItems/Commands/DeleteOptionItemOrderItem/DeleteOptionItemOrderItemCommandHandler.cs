using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.DeleteOptionItemOrderItem
{
	public class DeleteOptionItemOrderItemCommandHandler : IRequestHandler<DeleteOptionItemOrderItemCommand>
	{
		private readonly IOptionItemOrderItemService _optionitemorderitemService;

		public DeleteOptionItemOrderItemCommandHandler(IOptionItemOrderItemService optionitemorderitemservice)
		{
			_optionitemorderitemService = optionitemorderitemservice;
		}

		public async Task Handle(DeleteOptionItemOrderItemCommand request, CancellationToken cancellationToken)
		{
			await _optionitemorderitemService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
