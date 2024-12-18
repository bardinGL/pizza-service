using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.OrderItems;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.CreateOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.DeleteOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.RestoreOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Commands.UpdateOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetListOrderItemIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/order-items")]
	[ApiController]
	public class OrderItemsController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public OrderItemsController(ISender sender, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateOrderItemDto request)
		{
			var result = await _sender.Send(new CreateOrderItemCommand { CreateOrderItemDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		[HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOrderItemIgnoreQueryFilterDto query)
		{
			var result = await _sender.Send(new GetListOrderItemIgnoreQueryFilterQuery { GetListOrderItemIgnoreQueryFilterDto = query });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpGet()]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListOrderItemDto query)
		{
			var result = await _sender.Send(new GetListOrderItemQuery { GetListOrderItemDto = query });
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
			var result = await _sender.Send(new GetOrderItemByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOrderItemDto request)
		{
			var result = await _sender.Send(new UpdateOrderItemCommand { Id = id, UpdateOrderItemDto = request });
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
			await _sender.Send(new RestoreOrderItemCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteOrderItemCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
