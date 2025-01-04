using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZoneSchedules;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class StaffZoneScheduleProfile : Profile
    {
        public StaffZoneScheduleProfile()
        {
            CreateMap<StaffZoneScheduleDto, StaffZoneSchedule>().ReverseMap();
        }
    }
}
