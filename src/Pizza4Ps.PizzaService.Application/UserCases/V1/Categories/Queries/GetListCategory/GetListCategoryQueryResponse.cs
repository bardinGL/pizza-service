using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategory
{
    public class GetListCategoryQueryResponse : PaginatedResultDto<CategoryDto>
    {
        public GetListCategoryQueryResponse(List<CategoryDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
