using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers
{
	public class GetListOrderVoucherIgnoreQueryFilterDto : PaginatedRequestDto
	{
		public bool IsDeleted { get; set; } = false;
		public Guid? OrderId { get; set; }
		public Guid? VoucherId { get; set; }
	}
}
