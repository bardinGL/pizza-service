using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.CreateZone
{
    public class CreateZoneCommandHandler : IRequestHandler<CreateZoneCommand, CreateZoneCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IZoneService _zoneService;

        public CreateZoneCommandHandler(IMapper mapper, IZoneService zoneService)
        {
            _mapper = mapper;
            _zoneService = zoneService;
        }

        public async Task<CreateZoneCommandResponse> Handle(CreateZoneCommand request, CancellationToken cancellationToken)
        {
            var result = await _zoneService.CreateAsync(
                request.CreateZoneDto.Name,
                request.CreateZoneDto.Capacity,
                request.CreateZoneDto.Description,
                request.CreateZoneDto.Status);
            return new CreateZoneCommandResponse
            {
                Id = result
            };
        }
    }
}
