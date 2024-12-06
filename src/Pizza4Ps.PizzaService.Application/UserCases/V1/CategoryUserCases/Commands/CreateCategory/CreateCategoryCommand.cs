using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.CategoryUserCases.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
