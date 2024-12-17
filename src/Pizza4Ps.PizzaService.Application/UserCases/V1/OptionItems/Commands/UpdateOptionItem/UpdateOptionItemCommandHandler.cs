using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItem
{
	public class UpdateOptionItemCommandHandler : IRequestHandler<UpdateOptionItemCommand, UpdateOptionItemCommandResponse>
	{
		private readonly IOptionItemService _optionitemService;

		public UpdateOptionItemCommandHandler(IOptionItemService optionitemService)
		{
			_optionitemService = optionitemService;
		}

		public async Task<UpdateOptionItemCommandResponse> Handle(UpdateOptionItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemService.UpdateAsync(
				request.Id,
				request.UpdateOptionItemDto.Name,
				request.UpdateOptionItemDto.AdditionalPrice,
				request.UpdateOptionItemDto.OptionId);
			return new UpdateOptionItemCommandResponse
			{
				Id = result
			};
		}
	}
}
