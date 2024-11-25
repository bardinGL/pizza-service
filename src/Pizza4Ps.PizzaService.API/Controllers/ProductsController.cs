﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.ProductQueries.GetProduct;
using Pizza4Ps.PizzaService.Persistence.Helpers;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public ProductsController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            var userId = _httpContextAccessor.HttpContext.GetCurrentUserId();
            var result = await _sender.Send(command);
            return Ok(new ApiResponse<Guid>
            {
                Result = result,
                Message = MESSSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetProductAsync([FromQuery] GetProductQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse<PaginatedResult<GetProductQueryResponse>>
            {
                Result = result,
                Message = MESSSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}
