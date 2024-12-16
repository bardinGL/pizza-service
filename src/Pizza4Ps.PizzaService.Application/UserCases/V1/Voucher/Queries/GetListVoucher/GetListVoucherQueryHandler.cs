using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Voucher.Queries.GetListVoucher
{
    public class GetListVoucherQueryHandler : IRequestHandler<GetListVoucherQuery, GetListVoucherQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherRepository _voucherRepository;

        public GetListVoucherQueryHandler(IMapper mapper, IVoucherRepository voucherRepository)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }

        public async Task<GetListVoucherQueryResponse> Handle(GetListVoucherQuery request, CancellationToken cancellationToken)
        {
            var query = _voucherRepository.GetListAsNoTracking(
                x => (request.GetListVoucherDto.Code == null || x.Code.Contains(request.GetListVoucherDto.Code))
                && (request.GetListVoucherDto.DiscountType == null || x.DiscountType == request.GetListVoucherDto.DiscountType)
                && (request.GetListVoucherDto.ExpiryDate == null || x.ExpiryDate == request.GetListVoucherDto.ExpiryDate),
                includeProperties: request.GetListVoucherDto.includeProperties);
            var entities = await query
                .OrderBy(request.GetListVoucherDto.SortBy)
                .Skip(request.GetListVoucherDto.SkipCount).Take(request.GetListVoucherDto.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            var result = _mapper.Map<List<VoucherDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListVoucherQueryResponse(result, totalCount);
        }
    }
}
