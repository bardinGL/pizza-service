﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.CreateOption
{
	public class CreateOptionCommandHandler : IRequestHandler<CreateOptionCommand, ResultDto<Guid>>
	{
		private readonly IMapper _mapper;
		private readonly IOptionService _optionService;

		public CreateOptionCommandHandler(IMapper mapper, IOptionService optionService)
		{
			_mapper = mapper;
			_optionService = optionService;
		}

		public async Task<ResultDto<Guid>> Handle(CreateOptionCommand request, CancellationToken cancellationToken)
		{
			var result = await _optionService.CreateAsync(
				request.ProductId,
                request.Name,
				request.Description,
				request.SelectMany);
			return new ResultDto<Guid>
            {
				Id = result
			};
		}
	}
}
