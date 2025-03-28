using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Commands.CreateVoucher
{
    public class CreateVoucherCommandHandler : IRequestHandler<CreateVoucherCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherService _voucherService;

        public CreateVoucherCommandHandler(IMapper mapper, IVoucherService voucherService)
        {
            _mapper = mapper;
            _voucherService = voucherService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateVoucherCommand request, CancellationToken cancellationToken)
        {
            DiscountTypeEnum? discountType = null;
            if (!Enum.TryParse(request.DiscountType, true, out DiscountTypeEnum parsedStatus))
            {
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            }
            discountType = parsedStatus;
            var result = await _voucherService.CreateAsync(
                request.Code,
                discountType.Value,
                request.Amount,
                request.ExpiryDate,
                request.VoucherTypeId);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
