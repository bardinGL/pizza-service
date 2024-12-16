using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable
{
    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, CreateTableCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITableService _tableService;

        public CreateTableCommandHandler(IMapper mapper, ITableService tableService)
        {
            _mapper = mapper;
            _tableService = tableService;
        }

        public async Task<CreateTableCommandResponse> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var result = await _tableService.CreateAsync(
                request.CreateTableDto.TableNumber,
                request.CreateTableDto.Capacity,
                request.CreateTableDto.Status,
                request.CreateTableDto.ZoneId);
            return new CreateTableCommandResponse
            {
                Id = result
            };
        }
    }
}
