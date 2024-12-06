using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.CategoryUserCases.Commands.CreateCategory
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        public Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();       
        }
    }
}
