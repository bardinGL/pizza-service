using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class OrderItemProfile : Profile
	{
		public OrderItemProfile()
		{
			CreateMap<OrderItemDto, OrderItem>().ReverseMap();
		}
	}
}
