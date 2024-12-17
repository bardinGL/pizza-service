using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetStaffZoneById
{
    public class GetStaffZoneByIdQueryHandler : IRequestHandler<GetStaffZoneByIdQuery, GetStaffZoneByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffZoneRepository _StaffZoneRepository;

        public GetStaffZoneByIdQueryHandler(IMapper mapper, IStaffZoneRepository StaffZoneRepository)
        {
            _mapper = mapper;
            _StaffZoneRepository = StaffZoneRepository;
        }

        public async Task<GetStaffZoneByIdQueryResponse> Handle(GetStaffZoneByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _StaffZoneRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<StaffZoneDto>(entity);
            return new GetStaffZoneByIdQueryResponse
            {
                StaffZone = result
            };
        }
    }
}
