using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class OptionItemProfile : Profile
	{
		public OptionItemProfile()
		{
			CreateMap<OptionItemDto, OptionItem>().ReverseMap();
		}
	}
}
