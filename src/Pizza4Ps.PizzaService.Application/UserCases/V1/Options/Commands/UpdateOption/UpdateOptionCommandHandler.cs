using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOption
{
	public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand, UpdateOptionCommandResponse>
	{
		private readonly IOptionService _optionService;

		public UpdateOptionCommandHandler(IOptionService optionService)
		{
			_optionService = optionService;
		}

		public async Task<UpdateOptionCommandResponse> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionService.UpdateAsync(
				request.Id,
				request.UpdateOptionDto.Name,
				request.UpdateOptionDto.Description);
			return new UpdateOptionCommandResponse
			{
				Id = result
			};
		}
	}
}
