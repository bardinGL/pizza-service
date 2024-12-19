using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.CreateWorkingTime
{
	public class CreateWorkingTimeCommandHandler : IRequestHandler<CreateWorkingTimeCommand, CreateWorkingTimeCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IWorkingTimeService _WorkingTimeService;

		public CreateWorkingTimeCommandHandler(IMapper mapper, IWorkingTimeService WorkingTimeService)
		{
			_mapper = mapper;
			_WorkingTimeService = WorkingTimeService;
		}

		public async Task<CreateWorkingTimeCommandResponse> Handle(CreateWorkingTimeCommand request, CancellationToken cancellationToken)
		{
			var result = await _WorkingTimeService.CreateAsync(
				request.CreateWorkingTimeDto.DayOfWeek,
				request.CreateWorkingTimeDto.ShiftCode,
				request.CreateWorkingTimeDto.Name,
				request.CreateWorkingTimeDto.StartTime,
				request.CreateWorkingTimeDto.EndTime);
			return new CreateWorkingTimeCommandResponse
			{
				Id = result
			};
		}
	}
}
