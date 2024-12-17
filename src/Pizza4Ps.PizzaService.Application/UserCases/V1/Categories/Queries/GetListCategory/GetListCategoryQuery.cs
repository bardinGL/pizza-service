using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategory
{
    public class GetListCategoryQuery : IRequest<GetListCategoryQueryResponse>
    {
        public GetListCategoryDto GetListCategoryDto { get; set; }
    }
}

