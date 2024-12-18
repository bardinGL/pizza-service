using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucher
{
	public class GetListOrderVoucherQueryHandler : IRequestHandler<GetListOrderVoucherQuery, GetListOrderVoucherQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderVoucherRepository _OrderVoucherRepository;

		public GetListOrderVoucherQueryHandler(IMapper mapper, IOrderVoucherRepository OrderVoucherRepository)
		{
			_mapper = mapper;
			_OrderVoucherRepository = OrderVoucherRepository;
		}

		public async Task<GetListOrderVoucherQueryResponse> Handle(GetListOrderVoucherQuery request, CancellationToken cancellationToken)
		{
			var query = _OrderVoucherRepository.GetListAsNoTracking(
				x => (request.GetListOrderVoucherDto.OrderId == null || x.OrderId == request.GetListOrderVoucherDto.OrderId)
				&& (request.GetListOrderVoucherDto.VoucherId == null || x.VoucherId == request.GetListOrderVoucherDto.VoucherId),
				includeProperties: request.GetListOrderVoucherDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListOrderVoucherDto.SortBy)
				.Skip(request.GetListOrderVoucherDto.SkipCount).Take(request.GetListOrderVoucherDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.OrderVoucherErrorConstant.ORDERVOUCHER_NOT_FOUND);
			var result = _mapper.Map<List<OrderVoucherDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOrderVoucherQueryResponse(result, totalCount);
		}
	}
}
