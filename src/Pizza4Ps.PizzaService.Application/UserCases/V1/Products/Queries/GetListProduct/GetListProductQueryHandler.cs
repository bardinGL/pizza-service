﻿using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Queries.GetListProduct
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, PaginatedResultDto<ProductDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetListProductQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<PaginatedResultDto<ProductDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                && (request.Price == null || x.Price == request.Price)
                && (request.CategoryId == null || x.CategoryId == request.CategoryId)
                && (request.ProductType == null || x.ProductType.Equals(request.ProductType)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
            var result = _mapper.Map<List<ProductDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProductDto>(result, totalCount);
        }
    }
}
