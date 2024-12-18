using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Queries.GetListOrderVoucherIgnoreQueryFilter
{
	public class GetListOrderVoucherIgnoreQueryFilterQueryHandler : IRequestHandler<GetListOrderVoucherIgnoreQueryFilterQuery, GetListOrderVoucherIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IOrderVoucherRepository _OrderVoucherRepository;

		public GetListOrderVoucherIgnoreQueryFilterQueryHandler(IMapper mapper, IOrderVoucherRepository OrderVoucherRepository)
		{
			_mapper = mapper;
			_OrderVoucherRepository = OrderVoucherRepository;
		}

		public async Task<GetListOrderVoucherIgnoreQueryFilterQueryResponse> Handle(GetListOrderVoucherIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _OrderVoucherRepository.GetListAsNoTracking(includeProperties: request.GetListOrderVoucherIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListOrderVoucherIgnoreQueryFilterDto.OrderId == null || x.OrderId == request.GetListOrderVoucherIgnoreQueryFilterDto.OrderId)
					&& (request.GetListOrderVoucherIgnoreQueryFilterDto.VoucherId == null || x.VoucherId == request.GetListOrderVoucherIgnoreQueryFilterDto.VoucherId)
					&& x.IsDeleted == request.GetListOrderVoucherIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListOrderVoucherIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListOrderVoucherIgnoreQueryFilterDto.SkipCount).Take(request.GetListOrderVoucherIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<OrderVoucherDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListOrderVoucherIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
