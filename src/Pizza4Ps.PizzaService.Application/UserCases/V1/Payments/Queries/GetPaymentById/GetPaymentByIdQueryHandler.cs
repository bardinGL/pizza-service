﻿using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDto>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentRepository _PaymentRepository;

		public GetPaymentByIdQueryHandler(IMapper mapper, IPaymentRepository PaymentRepository)
		{
			_mapper = mapper;
			_PaymentRepository = PaymentRepository;
		}

		public async Task<PaymentDto> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
		{
			var entity = await _PaymentRepository.GetSingleByIdAsync(request.Id, request.includeProperties);
			var result = _mapper.Map<PaymentDto>(entity);
			return result;
		}
	}
}
