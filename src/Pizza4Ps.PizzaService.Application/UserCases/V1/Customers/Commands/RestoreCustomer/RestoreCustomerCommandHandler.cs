﻿using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.RestoreCustomer
{
    public class RestoreCustomerCommandHandler : IRequestHandler<RestoreCustomerCommand>
    {
        private readonly ICustomerService _customerService;

        public RestoreCustomerCommandHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task Handle(RestoreCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerService.RestoreAsync(request.Ids);
        }
    }
}
