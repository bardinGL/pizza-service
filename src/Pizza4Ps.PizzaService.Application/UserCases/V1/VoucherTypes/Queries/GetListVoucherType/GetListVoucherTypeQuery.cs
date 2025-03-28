using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Queries.GetListVoucherType
{
    public class GetListVoucherTypeQuery : PaginatedQuery<PaginatedResultDto<VoucherTypeDto>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TotalQuantity { get; set; }
        public string? DiscountType { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
