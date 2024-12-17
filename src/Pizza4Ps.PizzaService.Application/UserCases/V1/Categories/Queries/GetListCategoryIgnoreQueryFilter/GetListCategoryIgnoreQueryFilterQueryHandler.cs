using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategoryIgnoreQueryFilter
{
    public class GetListCategoryIgnoreQueryFilterQueryHandler : IRequestHandler<GetListCategoryIgnoreQueryFilterQuery, GetListCategoryIgnoreQueryFilterQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        public GetListCategoryIgnoreQueryFilterQueryHandler(IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _mapper = mapper;
            _CategoryRepository = CategoryRepository;
        }

        public async Task<GetListCategoryIgnoreQueryFilterQueryResponse> Handle(GetListCategoryIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _CategoryRepository.GetListAsNoTracking(includeProperties: request.GetListCategoryIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
                .Where(
                x => (request.GetListCategoryIgnoreQueryFilterDto.Name == null || x.Name.Contains(request.GetListCategoryIgnoreQueryFilterDto.Name))
                && (request.GetListCategoryIgnoreQueryFilterDto.Description == null || x.Description.Contains(request.GetListCategoryIgnoreQueryFilterDto.Description))
                    && x.IsDeleted == request.GetListCategoryIgnoreQueryFilterDto.IsDeleted);
            var entities = await query
                .OrderBy(request.GetListCategoryIgnoreQueryFilterDto.SortBy)
                .Skip(request.GetListCategoryIgnoreQueryFilterDto.SkipCount).Take(request.GetListCategoryIgnoreQueryFilterDto.TakeCount).ToListAsync();
            var result = _mapper.Map<List<CategoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCategoryIgnoreQueryFilterQueryResponse(result, totalCount);
        }
    }
}
