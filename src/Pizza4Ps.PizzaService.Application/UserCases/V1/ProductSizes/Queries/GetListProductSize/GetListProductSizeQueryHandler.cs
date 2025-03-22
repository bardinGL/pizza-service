﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductSizes.Queries.GetListProductSize
{
    public class GetListProductSizeQueryHandler : IRequestHandler<GetListProductSizeQuery, PaginatedResultDto<ProductSizeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProductSizeRepository _productSizeRepository;

        public GetListProductSizeQueryHandler(IMapper mapper, IProductSizeRepository productSizeRepository)
        {
            _mapper = mapper;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<PaginatedResultDto<ProductSizeDto>> Handle(GetListProductSizeQuery request, CancellationToken cancellationToken)
        {
            var query = _productSizeRepository.GetListAsNoTracking(
                x => (request.ProductId == null || x.ProductId.Contains(request.ProductId))
                && (request.RecipeId == null || x.RecipeId.Contains(request.RecipeId))
                && (request.SizeId == null || x.SizeId == request.SizeId)
                ,
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ProductSizeErrorConstant.PRODUCTSIZE_NOT_FOUND);
            var result = _mapper.Map<List<ProductSizeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ProductSizeDto>(result, totalCount);
        }
    }
}
