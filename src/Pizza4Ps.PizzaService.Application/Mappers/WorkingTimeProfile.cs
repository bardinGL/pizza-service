using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
	public class WorkingTimeProfile : Profile
	{
		public WorkingTimeProfile()
		{
			CreateMap<WorkingTimeDto, WorkingTime>().ReverseMap();
		}
	}
}
