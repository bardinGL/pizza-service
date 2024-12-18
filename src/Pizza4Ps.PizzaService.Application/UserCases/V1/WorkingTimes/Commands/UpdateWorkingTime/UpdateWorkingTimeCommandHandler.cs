using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.UpdateWorkingTime
{
	public class UpdateWorkingTimeCommandHandler : IRequestHandler<UpdateWorkingTimeCommand, UpdateWorkingTimeCommandResponse>
	{
		private readonly IWorkingTimeService _workingtimeService;

		public UpdateWorkingTimeCommandHandler(IWorkingTimeService workingtimeService)
		{
			_workingtimeService = workingtimeService;
		}

		public async Task<UpdateWorkingTimeCommandResponse> Handle(UpdateWorkingTimeCommand request, CancellationToken cancellationToken)
		{
			var result = await _workingtimeService.UpdateAsync(
				request.Id,
				request.UpdateWorkingTimeDto.DayOfWeek,
				request.UpdateWorkingTimeDto.ShiftCode,
				request.UpdateWorkingTimeDto.Name,
				request.UpdateWorkingTimeDto.StartTime,
				request.UpdateWorkingTimeDto.EndTime);
			return new UpdateWorkingTimeCommandResponse
			{
				Id = result
			};
		}
	}
}
