﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.CreateRecipe;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.DeleteRecipe;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.RestoreRecipe;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetListRecipe;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetRecipeById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public RecipesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        /// <remarks>
        ///Milligram,
        ///Gram,
        ///Kilogram,
        ///Milliliter,
        ///Liter,
        ///Piece,
        ///Teaspoon,
        ///Tablespoon
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRecipeCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        /// <remarks>
        ///Milligram,
        ///Gram,
        ///Kilogram,
        ///Milliliter,
        ///Liter,
        ///Piece,
        ///Teaspoon,
        ///Tablespoon
        /// </remarks>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListRecipeQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCustomerCodeAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetRecipeByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreRecipeCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManyAsync([FromRoute] Guid id, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteRecipeCommand
            {
                Ids = new List<Guid> { id },
                isHardDelete = isHardDeleted
            });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
