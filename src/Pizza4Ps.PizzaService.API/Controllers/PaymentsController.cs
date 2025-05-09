﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.WebhookPayOsDto;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CancelPaymentQRCode;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePaymentQRCode;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.DeletePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.PayOrderCash;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.RestorePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.UpdatePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.WebhookPayOS;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentInfo;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public PaymentsController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync([FromBody] CreatePaymentCommand request)
        //{
        //	var result = await _sender.Send(request);
        //	return Ok(new ApiResponse
        //	{
        //		Result = result,
        //		Message = Message.CREATED_SUCCESS,
        //		StatusCode = StatusCodes.Status201Created
        //	});
        //}

        [HttpPost("create-payment-qrcode/{orderId}")]
        public async Task<IActionResult> CreatePaymentLinkAsync([FromRoute] Guid orderId)
        {
            var result = await _sender.Send(new CreatePaymentQRCodeCommand
            {
                OrderId = orderId
            });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("cancel-payment-qrcode/{orderId}")]
        public async Task<IActionResult> CancelPaymentLinkAsync([FromRoute] Guid orderId)
        {
            await _sender.Send(new CancelPaymentQRCodeCommand
            {
                OrderId = orderId
            });
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("pay-order-by-cash/{orderId}")]
        public async Task<IActionResult> PayOrderByCashAsync([FromRoute] Guid orderId)
        {
            var result = await _sender.Send(new PayOrderCashCommand
            {
                OrderId = orderId
            });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        [HttpPost("webhook")]
        public async Task<IActionResult> PaymentWebhook([FromBody] WebhookType webhookDto)
        {
            var result = await _sender.Send(new WebhookPayOsCommand
            {
                WebhookDto = webhookDto
            });
            if (result == true)
            {
                return Ok(new { success = true });

            }
            else
            {
                return Ok(new { success = false });
            }
        } 
        [HttpGet("return-url-payos")]
        public async Task<IActionResult> ReturnUrlAsync([FromQuery] string orderCode)
        {
            try
            {
                var test = orderCode;
                return Ok();
            }
            catch (Exception ex)
            {
                // Log chi tiết lỗi, ví dụ dùng ILogger
                // _logger.LogError(ex, "Lỗi trong PaymentWebhook");
                return StatusCode(500, new { message = "Có lỗi xảy ra trong quá trình xử lý webhook", error = ex.Message });
            }
        }
        [HttpGet("get-payment-info")]
        public async Task<IActionResult> GetPaymentInfo([FromQuery] GetPaymentInfoQuery query)
        {
            await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }
        //[HttpPost("webhook/payment-successfully/{orderCode}")]
        //public async Task<IActionResult> CreateAsync()
        //{
        //    var result = await _sender.Send(new CreatePaymentLinkCommand());
        //    return Ok(new ApiResponse
        //    {
        //        Result = result,
        //        Message = Message.CREATED_SUCCESS,
        //        StatusCode = StatusCodes.Status201Created
        //    });
        //}
        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListPaymentIgnoreQueryFilterQuery query)
        {
            var result = await _sender.Send(query);
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListPaymentQuery query)
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
            var result = await _sender.Send(new GetPaymentByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePaymentCommand request)
        {
            request.Id = id;
            await _sender.Send(request);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = Message.UPDATED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("restore")]
        public async Task<IActionResult> RestoreManyAsync(List<Guid> ids)
        {
            await _sender.Send(new RestorePaymentCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeletePaymentCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
