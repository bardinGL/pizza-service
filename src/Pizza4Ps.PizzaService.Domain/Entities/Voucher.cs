using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string VoucherCode { get; set; }
        public VoucherTypeEnum DiscountType { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
