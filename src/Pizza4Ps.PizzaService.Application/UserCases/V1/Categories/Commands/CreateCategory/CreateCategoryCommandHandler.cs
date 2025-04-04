﻿using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
	{
		private readonly ICategoryService _categoryService;

		public CreateCategoryCommandHandler(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var result = await _categoryService.CreateAsync(
				request.CreateCategoryDto.Name,
				request.CreateCategoryDto.Description);
			return new CreateCategoryCommandResponse
			{
				Id = result
			};
		}
	}
}
