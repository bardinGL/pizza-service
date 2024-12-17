using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class StaffZoneProfile : Profile
    {
        public StaffZoneProfile()
        {
            CreateMap<StaffZoneDto, StaffZone>().ReverseMap();
        }
    }
}
