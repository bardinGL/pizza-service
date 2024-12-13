﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Staffs;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.CreateStaff;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.DeleteStaff;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.RestoreStaff;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.UpdateStaff;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/staffs")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public StaffsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStaffDto request)
        {
            var result = await _sender.Send(new CreateStaffCommand { CreateStaffDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetListAsync([FromQuery] GetListProductQuery query)
        //{
        //	var result = await _sender.Send(query);
        //	return Ok(new ApiResponse
        //	{
        //		Result = result,
        //		Message = MESSAGE.GET_SUCCESS,
        //		StatusCode = StatusCodes.Status200OK
        //	});
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        //{
        //	var result = await _sender.Send(new GetProductByIdQuery { Id = id });
        //	return Ok(new ApiResponse
        //	{
        //		Result = result,
        //		Message = MESSAGE.GET_SUCCESS,
        //		StatusCode = StatusCodes.Status200OK
        //	});
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateStaffDto request)
        {
            var result = await _sender.Send(new UpdateStaffCommand { Id = id, UpdateStaffDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestoreStaffCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteStaffCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
