using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter
{
	public class GetListPaymentIgnoreQueryFilterQueryHandler : IRequestHandler<GetListPaymentIgnoreQueryFilterQuery, GetListPaymentIgnoreQueryFilterQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentRepository _PaymentRepository;

		public GetListPaymentIgnoreQueryFilterQueryHandler(IMapper mapper, IPaymentRepository PaymentRepository)
		{
			_mapper = mapper;
			_PaymentRepository = PaymentRepository;
		}

		public async Task<GetListPaymentIgnoreQueryFilterQueryResponse> Handle(GetListPaymentIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
		{
			var query = _PaymentRepository.GetListAsNoTracking(includeProperties: request.GetListPaymentIgnoreQueryFilterDto.includeProperties).IgnoreQueryFilters()
				.Where(
					x => (request.GetListPaymentIgnoreQueryFilterDto.Amount == null || x.Amount == request.GetListPaymentIgnoreQueryFilterDto.Amount)
					&& (request.GetListPaymentIgnoreQueryFilterDto.PaymentMethod == null || x.PaymentMethod == request.GetListPaymentIgnoreQueryFilterDto.PaymentMethod)
					&& (request.GetListPaymentIgnoreQueryFilterDto.Status == null || x.Status.Contains(request.GetListPaymentIgnoreQueryFilterDto.Status))
					&& (request.GetListPaymentIgnoreQueryFilterDto.OrderId == null || x.OrderId == request.GetListPaymentIgnoreQueryFilterDto.OrderId)
					&& x.IsDeleted == request.GetListPaymentIgnoreQueryFilterDto.IsDeleted);
			var entities = await query
				.OrderBy(request.GetListPaymentIgnoreQueryFilterDto.SortBy)
				.Skip(request.GetListPaymentIgnoreQueryFilterDto.SkipCount).Take(request.GetListPaymentIgnoreQueryFilterDto.TakeCount).ToListAsync();
			var result = _mapper.Map<List<PaymentDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListPaymentIgnoreQueryFilterQueryResponse(result, totalCount);
		}
	}
}
