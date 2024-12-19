using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetStaffScheduleById
{
    internal class GetStaffScheduleByIdQueryHandler : IRequestHandler<GetStaffScheduleByIdQuery, GetStaffScheduleByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffScheduleRepository _StaffScheduleRepository;

        public GetStaffScheduleByIdQueryHandler(IMapper mapper, IStaffScheduleRepository StaffScheduleRepository)
        {
            _mapper = mapper;
            _StaffScheduleRepository = StaffScheduleRepository;
        }

        public async Task<GetStaffScheduleByIdQueryResponse> Handle(GetStaffScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _StaffScheduleRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<StaffScheduleDto>(entity);
            return new GetStaffScheduleByIdQueryResponse
            {
                StaffSchedule = result
            };
        }
    }
}
