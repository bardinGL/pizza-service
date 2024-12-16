using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.Vouchers
{
    public class GetListVoucherIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public string? Code { get; set; }
        public DiscountTypeEnum? DiscountType { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
