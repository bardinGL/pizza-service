using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment
{
	public class GetListPaymentQueryHandler : IRequestHandler<GetListPaymentQuery, GetListPaymentQueryResponse>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentRepository _PaymentRepository;

		public GetListPaymentQueryHandler(IMapper mapper, IPaymentRepository PaymentRepository)
		{
			_mapper = mapper;
			_PaymentRepository = PaymentRepository;
		}

		public async Task<GetListPaymentQueryResponse> Handle(GetListPaymentQuery request, CancellationToken cancellationToken)
		{
			var query = _PaymentRepository.GetListAsNoTracking(
				x => (request.GetListPaymentDto.Amount == null || x.Amount == request.GetListPaymentDto.Amount)
				&& (request.GetListPaymentDto.PaymentMethod == null || x.PaymentMethod == request.GetListPaymentDto.PaymentMethod)
				&& (request.GetListPaymentDto.Status == null || x.Status.Contains(request.GetListPaymentDto.Status)),
				includeProperties: request.GetListPaymentDto.includeProperties);
			var entities = await query
				.OrderBy(request.GetListPaymentDto.SortBy)
				.Skip(request.GetListPaymentDto.SkipCount).Take(request.GetListPaymentDto.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.PaymentErrorConstant.PAYMENT_NOT_FOUND);
			var result = _mapper.Map<List<PaymentDto>>(entities);
			var totalCount = await query.CountAsync();
			return new GetListPaymentQueryResponse(result, totalCount);
		}
	}
}
