using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Queries.GetStaffById
{
    public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQuery, GetStaffByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;

        public GetStaffByIdQueryHandler(IMapper mapper, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
        }

        public async Task<GetStaffByIdQueryResponse> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _staffRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<StaffDto>(entity);
            return new GetStaffByIdQueryResponse
            {
                Staff = result
            };
        }
    }
}
