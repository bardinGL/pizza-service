﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.LoginCustomer;
using Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.RegisterCustomer;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/auth/customer")]
    [ApiController]
    public class AppUserCustomerController : ControllerBase
    {
        private readonly ISender _sender;

        public AppUserCustomerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAppUserCustomerAsync([FromBody] RegisterCustomerCommand request)
        {
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginCustomerAsync([FromBody] LoginCustomerCommand request)
        {
            var result = await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
    }
}
