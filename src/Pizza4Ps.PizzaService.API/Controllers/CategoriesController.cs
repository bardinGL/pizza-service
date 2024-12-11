﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.CreateCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.DeleteCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.RestoreCategory;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ISender _sender;

        public CategoriesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command)
        {
            var result = await _sender.Send(command);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = MESSAGE.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetListAsync([FromQuery] GetListProductQuery query)
        //{
        //    var result = await _sender.Send(query);
        //    return Ok(new ApiResponse
        //    {
        //        Result = result,
        //        Message = MESSAGE.GET_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        //{
        //    var result = await _sender.Send(new GetProductByIdQuery { Id = id });
        //    return Ok(new ApiResponse
        //    {
        //        Result = result,
        //        Message = MESSAGE.GET_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductCommand command)
        //{
        //    command.Id = id;            command.Id = id;
        //    var result = await _sender.Send(command);
        //    return Ok(new ApiResponse
        //    {
        //        Result = result,
        //        Message = MESSAGE.UPDATED_SUCCESS,
        //        StatusCode = StatusCodes.Status200OK
        //    });
        //}

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreCategoryCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = MESSAGE.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteCategoryCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = MESSAGE.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
