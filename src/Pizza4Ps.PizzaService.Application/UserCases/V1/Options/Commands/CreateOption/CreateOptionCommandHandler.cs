using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.CreateOption
{
	public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, CreateOptionCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionService _optionService;

		public CreateOptionCommandHandler(IMapper mapper, IOptionService optionService)
		{
			_mapper = mapper;
			_optionService = optionService;
		}

		public async Task<CreateOptionCommandResponse> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionService.CreateAsync(
				request.CreateOptionDto.Name,
				request.CreateOptionDto.Description);
			return new CreateOptionCommandResponse
			{
				Id = result
			};
		}
	}
}
