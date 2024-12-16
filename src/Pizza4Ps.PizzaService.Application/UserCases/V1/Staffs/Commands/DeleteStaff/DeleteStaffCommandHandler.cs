using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.DeleteStaff
{
	public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand>
	{
		private readonly IStaffService _staffService;

		public DeleteStaffCommandHandler(IStaffService staffService)
		{
			_staffService = staffService;
		}

		public async Task Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
		{
			await _staffService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
