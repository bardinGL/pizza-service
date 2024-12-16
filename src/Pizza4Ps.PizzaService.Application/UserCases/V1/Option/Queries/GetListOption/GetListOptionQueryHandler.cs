using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Options;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetListOption
{
    public class GetListOptionQueryHandler : IRequestHandler<GetListOptionQuery, GetListOptionQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOptionRepository _optionRepository;

        public GetListOptionQueryHandler(IMapper mapper, IOptionRepository optionRepository)
        {
            _mapper = mapper;
            _optionRepository = optionRepository;
        }

        public async Task<GetListOptionQueryResponse> Handle(GetListOptionQuery request, CancellationToken cancellationToken)
        {
            var query = _optionRepository.GetListAsNoTracking(
                x => (request.GetListOptionDto.Name == null || x.Name.Contains(request.GetListOptionDto.Name))
                && (request.GetListOptionDto.Description == null || x.Description.Contains(request.GetListOptionDto.Description)),
                includeProperties: request.GetListOptionDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListOptionDto.SortBy)
                .Skip(request.GetListOptionDto.SkipCount).Take(request.GetListOptionDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
            var result = _mapper.Map<List<OptionDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListOptionQueryResponse(result, totalCount);
        }
    }
}