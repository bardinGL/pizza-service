using AutoMapper;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.UpdateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.ProductQueries.GetProduct;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductQueryResponse, Product>().ReverseMap();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
