using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.DeleteOptionItem
{
	public class DeleteOptionItemCommandHandler : IRequestHandler<DeleteOptionItemCommand>
	{
		private readonly IOptionItemService _optionitemService;

		public DeleteOptionItemCommandHandler(IOptionItemService optionitemservice)
		{
			_optionitemService = optionitemservice;
		}

		public async Task Handle(DeleteOptionItemCommand request, CancellationToken cancellationToken)
		{
			await _optionitemService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
