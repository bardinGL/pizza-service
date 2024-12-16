using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableById
{
    public class GetTableByIdQueryHandler : IRequestHandler<GetTableByIdQuery, GetTableByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITableRepository _tableRepository;

        public GetTableByIdQueryHandler(IMapper mapper, ITableRepository tableRepository)
        {
            _mapper = mapper;
            _tableRepository = tableRepository;
        }
        public async Task<GetTableByIdQueryResponse> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _tableRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<TableDto>(entity);
            return new GetTableByIdQueryResponse
            {
                Table = result
            };
        }
    }
}
