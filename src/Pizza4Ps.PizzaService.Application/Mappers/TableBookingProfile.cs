using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class TableBookingProfile : Profile
	{
		public TableBookingProfile()
		{
			CreateMap<TableBookingDto, TableBooking>().ReverseMap();
		}
	}
}
