using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Queries.GetListVoucher
{
    public class GetListVoucherQuery : IRequest<GetListVoucherQueryResponse>
    {
        public GetListVoucherDto GetListVoucherDto { get; set; }
    }
}
