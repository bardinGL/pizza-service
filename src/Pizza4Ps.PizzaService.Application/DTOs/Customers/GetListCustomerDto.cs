using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.DTOs.Customers
{
    public class GetListCustomerDto : PaginatedRequestDto
    {
        public string? FullName { get; set; }
        public string? Phone { get; set; }
    }
}
