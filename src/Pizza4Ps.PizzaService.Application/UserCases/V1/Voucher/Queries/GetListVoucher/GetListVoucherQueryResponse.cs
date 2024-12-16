using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Queries.GetListVoucher
{
    public class GetListVoucherQueryResponse : PaginatedResultDto<VoucherDto>
    {
        public GetListVoucherQueryResponse(List<VoucherDto> items, long totalCount) : base(items, totalCount)
        {
        }
    }
}
