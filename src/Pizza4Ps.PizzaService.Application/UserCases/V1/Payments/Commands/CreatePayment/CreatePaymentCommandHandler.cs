using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePayment
{
	public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, CreatePaymentCommandResponse>
	{
		private readonly IMapper _mapper;
		private readonly IPaymentService _PaymentService;

		public CreatePaymentCommandHandler(IMapper mapper, IPaymentService PaymentService)
		{
			_mapper = mapper;
			_PaymentService = PaymentService;
		}

		public async Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
		{
			var result = await _PaymentService.CreateAsync(
				request.CreatePaymentDto.Amount,
				request.CreatePaymentDto.PaymentMethod,
				request.CreatePaymentDto.Status,
				request.CreatePaymentDto.OrderId);
			return new CreatePaymentCommandResponse
			{
				Id = result
			};
		}
	}
}
