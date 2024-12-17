using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategoryIgnoreQueryFilter
{
    public class GetListCategoryIgnoreQueryFilterQuery : IRequest<GetListCategoryIgnoreQueryFilterQueryResponse>
    {
        public GetListCategoryIgnoreQueryFilterDto GetListCategoryIgnoreQueryFilterDto { get; set; }
    }
}

