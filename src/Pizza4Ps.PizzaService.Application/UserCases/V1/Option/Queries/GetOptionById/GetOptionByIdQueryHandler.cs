using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Options;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetOptionById
{
    public class GetOptionByIdQueryHandler : IRequestHandler<GetOptionByIdQuery, GetOptionByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;

        public GetOptionByIdQueryHandler(IMapper mapper, IOptionRepository optionRepository)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
        }

        public async Task<GetOptionByIdQueryResponse> Handle(GetOptionByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _optionRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
            var result = _mapper.Map<OptionDto>(entity);
            return new GetOptionByIdQueryResponse
            {
                Option = result
            };
        }
    }
}
