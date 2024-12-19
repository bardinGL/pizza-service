using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class StaffScheduleProfile : Profile
    {
        public StaffScheduleProfile()
        {
            CreateMap<StaffScheduleDto, StaffSchedule>().ReverseMap();
        }
    }
}
