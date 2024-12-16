using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.OrderVouchers;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.CreateOrderVoucher;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.DeleteOrderVoucher;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.RestoreOrderVoucher;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderVouchers.Commands.UpdateOrderVoucher;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderVouchersController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public OrderVouchersController(IHttpContextAccessor httpContextAccessor, ISender sender)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateOrderVoucherDto request)
		{
			var result = await _sender.Send(new CreateOrderVoucherCommand { CreateOrderVoucherDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		//[HttpGet("ignore-filter")]
		//public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOrderVoucherIgnoreQueryFilterDto query)
		//{
		//	var result = await _sender.Send(new GetListOrderVoucherIgnoreQueryFilterQuery { GetListOrderVoucherIgnoreQueryFilterDto = query });
		//	return Ok(new ApiResponse
		//	{
		//		Result = result,
		//		Message = Message.GET_SUCCESS,
		//		StatusCode = StatusCodes.Status200OK
		//	});
		//}

		//[HttpGet()]
		//public async Task<IActionResult> GetListAsync([FromQuery] GetListOrderVoucherDto query)
		//{
		//	var result = await _sender.Send(new GetListOrderVoucherQuery { GetListOrderVoucherDto = query });
		//	return Ok(new ApiResponse
		//	{
		//		Result = result,
		//		Message = Message.GET_SUCCESS,
		//		StatusCode = StatusCodes.Status200OK
		//	});
		//}

		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetSingleByIdAsync([FromRoute] Guid id)
		//{
		//	var result = await _sender.Send(new GetOrderVoucherByIdQuery { Id = id });
		//	return Ok(new ApiResponse
		//	{
		//		Result = result,
		//		Message = Message.GET_SUCCESS,
		//		StatusCode = StatusCodes.Status200OK
		//	});
		//}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderVoucherDto request)
		{
			var result = await _sender.Send(new UpdateOrderVoucherCommand { Id = id, UpdateOrderVoucherDto = request });
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
			await _sender.Send(new RestoreOrderVoucherCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteOrderVoucherCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
