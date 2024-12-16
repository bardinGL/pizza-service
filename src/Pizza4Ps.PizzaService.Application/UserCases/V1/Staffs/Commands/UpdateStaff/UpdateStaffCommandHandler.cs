using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.UpdateStaff
{
	public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, UpdateStaffCommandResponse>
	{
		private readonly IStaffService _staffService;

		public UpdateStaffCommandHandler(IStaffService staffService)
		{
			_staffService = staffService;
		}

		public async Task<UpdateStaffCommandResponse> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
		{
			var result = await _staffService.UpdateAsync(
				request.Id,
				request.UpdateStaffDto.Code,
				request.UpdateStaffDto.Name,
				request.UpdateStaffDto.Phone,
				request.UpdateStaffDto.Email,
				request.UpdateStaffDto.StaffType,
				request.UpdateStaffDto.Status);
			return new UpdateStaffCommandResponse
			{
				Id = result
			};
		}
	}
}
