using MediatR;
using Pizza4Ps.PizzaService.Application.Models;

namespace Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery
{
    public abstract class BasePaginatedQuery
    {
        public int TakeCount { get; set; } = 20;
        public int SkipCount { get; set; } = 0;
        public string SortBy { get; set; } = "CreatedDate Desc";
    }
}
