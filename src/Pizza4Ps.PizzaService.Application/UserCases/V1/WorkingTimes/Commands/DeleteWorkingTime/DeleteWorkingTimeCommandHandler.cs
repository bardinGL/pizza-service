using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.DeleteWorkingTime
{
	public class DeleteWorkingTimeCommandHandler : IRequestHandler<DeleteWorkingTimeCommand>
	{
		private readonly IWorkingTimeService _workingtimeService;

		public DeleteWorkingTimeCommandHandler(IWorkingTimeService workingtimeservice)
		{
			_workingtimeService = workingtimeservice;
		}

		public async Task Handle(DeleteWorkingTimeCommand request, CancellationToken cancellationToken)
		{
			await _workingtimeService.DeleteAsync(request.Ids, request.isHardDelete);
		}
	}
}
