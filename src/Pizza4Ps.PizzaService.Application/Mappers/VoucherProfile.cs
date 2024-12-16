using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs.Vouchers;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class VoucherProfile : Profile
    {
        public VoucherProfile()
        {
            CreateMap<VoucherDto, Voucher>().ReverseMap();
        }
    }
}
