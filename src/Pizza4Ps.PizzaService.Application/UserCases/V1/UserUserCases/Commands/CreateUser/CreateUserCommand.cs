using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.CategoryUserCases.Commands.CreateCategory
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
