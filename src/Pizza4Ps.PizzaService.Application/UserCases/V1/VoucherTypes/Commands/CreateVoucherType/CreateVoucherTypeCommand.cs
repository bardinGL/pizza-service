using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Commands.CreateVoucherType
{
    public class CreateVoucherTypeCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int TotalQuantity { get; set; }

        public string? DiscountType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
