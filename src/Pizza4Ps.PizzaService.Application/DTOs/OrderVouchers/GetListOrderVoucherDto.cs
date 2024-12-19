using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers
{
	public class GetListOrderVoucherDto : PaginatedRequestDto
	{
		public Guid? OrderId { get; set; }
		public Guid? VoucherId { get; set; }
	}
}
