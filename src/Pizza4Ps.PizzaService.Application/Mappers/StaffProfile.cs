using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<StaffDto, Staff>().ReverseMap();
        }
    }
}
