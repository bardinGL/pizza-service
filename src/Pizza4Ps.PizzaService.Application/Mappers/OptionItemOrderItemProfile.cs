using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class OptionItemOrderItemProfile : Profile
	{
		public OptionItemOrderItemProfile()
		{
			CreateMap<OptionItemOrderItemDto, OptionItemOrderItem>().ReverseMap();
		}
	}
}
