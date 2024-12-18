using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.RestoreWorkingTime
{
	public class RestoreWorkingTimeCommandHandler : IRequestHandler<RestoreWorkingTimeCommand>
	{
		private readonly IWorkingTimeService _workingtimeService;

		public RestoreWorkingTimeCommandHandler(IWorkingTimeService workingtimeService)
		{
			_workingtimeService = workingtimeService;
		}

		public async Task Handle(RestoreWorkingTimeCommand request, CancellationToken cancellationToken)
		{
			await _workingtimeService.RestoreAsync(request.Ids);
		}
	}
}
