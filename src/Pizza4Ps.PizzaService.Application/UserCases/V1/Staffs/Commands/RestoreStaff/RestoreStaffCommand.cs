using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.RestoreStaff
{
	public class RestoreStaffCommand : IRequest
	{
		public List<Guid> Ids { get; set; }
	}
}
