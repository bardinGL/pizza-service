using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.DeleteStaffZone
{
    public class DeleteStaffZoneCommandHandler : IRequestHandler<DeleteStaffZoneCommand>
    {
        private readonly IStaffZoneService _StaffZoneService;

        public DeleteStaffZoneCommandHandler(IStaffZoneService StaffZoneservice)
        {
            _StaffZoneService = StaffZoneservice;
        }

        public async Task Handle(DeleteStaffZoneCommand request, CancellationToken cancellationToken)
        {
            await _StaffZoneService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
