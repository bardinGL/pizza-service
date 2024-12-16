using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
