using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.DeleteOption
{
	public class DeleteOptionCommandHandler : IRequestHandler<DeleteOptionCommand>
	{
		private readonly IOptionService _optionService;

		public DeleteOptionCommandHandler(IOptionService optionService)
		{
			_optionService = optionService;
		}

		public async Task Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
		{
			await _optionService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
