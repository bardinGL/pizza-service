using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Options;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Queries.GetListOptionIgnoreQueryFilter
{
	public class GetListOptionIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOptionIgnoreQueryFilterQuery, GetListOptionIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOptionRepository _optionRepository;

		public GetListOptionIgnoreQueryFilterQueryHandler(IMapper mapper, IOptionRepository optionRepository)
		{
			_mapper = mapper;
			_optionRepository = optionRepository;
		}

		public async Task<GetListOptionIgnoreQueryFilterQueryResponse> Handle(GetListOptionIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _optionRepository.GetListAsNoTracking(includeProperties: request.GetListOptionIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListOptionIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListOptionIgnoreQueryFilterDto.Name))
					&& (request.GetListOptionIgnoreQueryFilterDto.Description == null || x.Description.Contains(request.GetListOptionIgnoreQueryFilterDto.Description))
					&& x.IsDeleted == request.GetListOptionIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListOptionIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListOptionIgnoreQueryFilterDto.SkipCount).Take(request.GetListOptionIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OptionDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOptionIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
