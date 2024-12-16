using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQuery : IRequest<GetListCustomerQueryResponse>
    {
        public GetListCustomerDto GetListCustomerDto { get; set; }

    }
}
