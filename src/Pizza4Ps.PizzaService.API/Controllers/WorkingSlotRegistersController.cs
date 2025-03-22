﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateStatusToServed;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.RegisterWorkingSlot;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.UpdateStatusToApproved;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Commands.UpdateStatusToRejected;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetListWorkingSlotRegister;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingSlotRegisters.Queries.GetWorkingSlotRegisterById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/working-slot-registers")]
    [ApiController]
    public class WorkingSlotRegistersController : ControllerBase
    {
        private readonly ISender _sender;

        public WorkingSlotRegistersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterWorkingSlotCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpPut("rejected/{id}")]
        public async Task<IActionResult> rejectedAsync([FromRoute] Guid id)
        {
            await _sender.Send(new UpdateStatusToRejectedCommand
            {
                Id = id
            });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("approved/{id}")]
        public async Task<IActionResult> approvedAsync([FromRoute] Guid id)
        {
            await _sender.Send(new UpdateStatusToApprovedCommand
            {
                Id = id
            });

            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListWorkingSlotRegisterQuery query)
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
        public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetWorkingSlotRegisterByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
