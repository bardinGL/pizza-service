using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.DeleteStaffSchedule
{
    public class DeleteStaffScheduleCommandHandler : IRequestHandler<DeleteStaffScheduleCommand>
    {
        private readonly IStaffScheduleService _StaffScheduleService;

        public DeleteStaffScheduleCommandHandler(IStaffScheduleService StaffScheduleservice)
        {
            _StaffScheduleService = StaffScheduleservice;
        }

        public async Task Handle(DeleteStaffScheduleCommand request, CancellationToken cancellationToken)
        {
            await _StaffScheduleService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
