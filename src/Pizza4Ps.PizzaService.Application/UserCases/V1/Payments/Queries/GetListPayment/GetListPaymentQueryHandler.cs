﻿using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment
{
    public class GetListPaymentQueryHandler : IRequestHandler<GetListPaymentQuery, PaginatedResultDto<PaymentDto>>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentRepository _PaymentRepository;

		public GetListPaymentQueryHandler(IMapper mapper, IPaymentRepository PaymentRepository)
		{
			_mapper = mapper;
			_PaymentRepository = PaymentRepository;
		}

		public async Task<PaginatedResultDto<PaymentDto>> Handle(GetListPaymentQuery request, CancellationToken cancellationToken)
		{
			var query = _PaymentRepository.GetListAsNoTracking(
				x => (request.Amount == null || x.Amount == request.Amount)
				&& (request.PaymentMethod == null || x.PaymentMethod == request.PaymentMethod)
				&& (request.Status == null || x.Status.Contains(request.Status))
				&& (request.OrderId == null || x.OrderId == request.OrderId),
				includeProperties: request.IncludeProperties);
			var entities = await query
				.OrderBy(request.SortBy)
				.Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
			if (!entities.Any())
				throw new BusinessException(BussinessErrorConstants.PaymentErrorConstant.PAYMENT_NOT_FOUND);
			var result = _mapper.Map<List<PaymentDto>>(entities);
			var totalCount = await query.CountAsync();
			return new PaginatedResultDto<PaymentDto>(result, totalCount);
		}
	}
}
