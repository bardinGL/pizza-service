using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.RestoreOption
{
	public class RestoreOptionCommandHandler : IRequestHandler<RestoreOptionCommand>
	{
		private readonly IOptionService _optionService;

		public RestoreOptionCommandHandler(IOptionService optionService)
		{
			_optionService = optionService;
		}

		public async Task Handle(RestoreOptionCommand request, CancellationToken cancellationToken)
		{
			await _optionService.RestoreAsync(request.Ids);
		}
	}
}
