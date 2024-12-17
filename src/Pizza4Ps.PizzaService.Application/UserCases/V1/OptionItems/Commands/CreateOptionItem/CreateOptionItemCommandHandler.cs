using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem
{
	public class CreateOptionItemCommandHandler : IRequestHandler<CreateOptionItemCommand, CreateOptionItemCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionItemService _optionitemService;

		public CreateOptionItemCommandHandler(IMapper mapper, IOptionItemService optionitemService)
		{
			_mapper = mapper;
			_optionitemService = optionitemService;
		}

		public async Task<CreateOptionItemCommandResponse> Handle(CreateOptionItemCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionitemService.CreateAsync(
				request.CreateOptionItemDto.Name,
				request.CreateOptionItemDto.AdditionalPrice,
				request.CreateOptionItemDto.OptionId);
			return new CreateOptionItemCommandResponse
			{
				Id = result
			};
		}
	}
}
