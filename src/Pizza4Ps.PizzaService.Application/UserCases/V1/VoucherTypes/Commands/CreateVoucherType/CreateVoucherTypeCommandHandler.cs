using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Commands.CreateVoucherType
{
    public class CreateVoucherTypeCommandHandler : IRequestHandler<CreateVoucherTypeCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherTypeService _voucherTypeService;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateVoucherTypeCommandHandler(IMapper mapper, IVoucherTypeService voucherTypeService, IVoucherRepository voucherRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _voucherTypeService = voucherTypeService;
            _voucherRepository = voucherRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultDto<Guid>> Handle(CreateVoucherTypeCommand request, CancellationToken cancellationToken)
        {
            DiscountTypeEnum? discountType = null;
            if (!Enum.TryParse(request.DiscountType, true, out DiscountTypeEnum parsedStatus))
            {
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            }
            discountType = parsedStatus;
            var voucherTypeId = await _voucherTypeService.CreateAsync(
                request.Name,
                request.Description,
                request.TotalQuantity,
                discountType.Value,
                request.Amount,
                request.ExpireDate
                
                );

            var timestamp = DateTimeOffset.UtcNow.ToString("HHmmss");
            var vouchers = new List<Voucher>();
            for (int i = 0; i < request.TotalQuantity; i++)
            {
                var code = $"{timestamp}{i:00}";

                var voucher = new Voucher(
                    id: Guid.NewGuid(),
                    code: code,
                    discountType: discountType.Value,
                    amount: request.Amount,
                    expiryDate: request.ExpireDate,
                    voucherTypeId: voucherTypeId
                );

                vouchers.Add(voucher);
            }
            _voucherRepository.AddRange(vouchers);
            await _unitOfWork.SaveChangeAsync();
            return new ResultDto<Guid>
            {
                Id = voucherTypeId
            };
        }
    }
}
