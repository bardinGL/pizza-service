using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class PaymentProfile : Profile
	{
		public PaymentProfile()
		{
			CreateMap<PaymentDto, Payment>().ReverseMap();
		}
	}
}
