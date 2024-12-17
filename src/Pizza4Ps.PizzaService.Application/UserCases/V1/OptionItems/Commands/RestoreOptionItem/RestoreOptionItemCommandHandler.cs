using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.RestoreOptionItem
{
	public class RestoreOptionItemCommandHandler : IRequestHandler<RestoreOptionItemCommand>
	{
		private readonly IOptionItemService _optionitemService;

		public RestoreOptionItemCommandHandler(IOptionItemService optionitemService)
		{
			_optionitemService = optionitemService;
		}

		public async Task Handle(RestoreOptionItemCommand request, CancellationToken cancellationToken)
		{
			await _optionitemService.RestoreAsync(request.Ids);
		}
	}
}
