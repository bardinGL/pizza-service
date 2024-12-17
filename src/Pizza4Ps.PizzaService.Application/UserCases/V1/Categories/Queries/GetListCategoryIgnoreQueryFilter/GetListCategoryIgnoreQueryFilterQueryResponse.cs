using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategoryIgnoreQueryFilter
{
    public class GetListCategoryIgnoreQueryFilterQueryResponse : PaginatedResultDto<CategoryDto>
    {
        public GetListCategoryIgnoreQueryFilterQueryResponse(List<CategoryDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
