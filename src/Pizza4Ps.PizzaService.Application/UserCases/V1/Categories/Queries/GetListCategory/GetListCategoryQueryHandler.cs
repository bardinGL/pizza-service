using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategory
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, GetListCategoryQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _CategoryRepository;

        public GetListCategoryQueryHandler(IMapper mapper, ICategoryRepository CategoryRepository)
        {
            _mapper = mapper;
            _CategoryRepository = CategoryRepository;
        }

        public async Task<GetListCategoryQueryResponse> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var query = _CategoryRepository.GetListAsNoTracking(
                x => (request.GetListCategoryDto.Name == null || x.Name.Contains(request.GetListCategoryDto.Name))
                && (request.GetListCategoryDto.Description == null || x.Description.Contains(request.GetListCategoryDto.Description))
                ,
                includeProperties: request.GetListCategoryDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListCategoryDto.SortBy)
                .Skip(request.GetListCategoryDto.SkipCount).Take(request.GetListCategoryDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.CategoryErrorConstant.CATEGORY_NOT_FOUND);
            var result = _mapper.Map<List<CategoryDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCategoryQueryResponse(result, totalCount);
        }
    }
}
