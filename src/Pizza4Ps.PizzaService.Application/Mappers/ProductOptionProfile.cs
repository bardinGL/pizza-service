using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.ProductOptions;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class ProductOptionProfile : Profile
	{
		public ProductOptionProfile()
		{
			CreateMap<ProductOptionDto, ProductOption>().ReverseMap();
		}
	}
}
