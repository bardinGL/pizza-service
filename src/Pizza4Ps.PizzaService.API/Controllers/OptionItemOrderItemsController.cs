using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItemOrderItems;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.CreateOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.DeleteOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.RestoreOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Commands.UpdateOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetListOptionItemOrderItemIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItemOrderItems.Queries.GetOptionItemOrderItemById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/option-item-order-items")]
	[ApiController]
	public class OptionItemOrderItemsController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public OptionItemOrderItemsController(ISender sender, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateOptionItemOrderItemDto request)
		{
			var result = await _sender.Send(new CreateOptionItemOrderItemCommand { CreateOptionItemOrderItemDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		[HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOptionItemOrderItemIgnoreQueryFilterDto query)
		{
			var result = await _sender.Send(new GetListOptionItemOrderItemIgnoreQueryFilterQuery { GetListOptionItemOrderItemIgnoreQueryFilterDto = query });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpGet()]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListOptionItemOrderItemDto query)
		{
			var result = await _sender.Send(new GetListOptionItemOrderItemQuery { GetListOptionItemOrderItemDto = query });
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
			var result = await _sender.Send(new GetOptionItemOrderItemByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOptionItemOrderItemDto request)
		{
			var result = await _sender.Send(new UpdateOptionItemOrderItemCommand { Id = id, UpdateOptionItemOrderItemDto = request });
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
			await _sender.Send(new RestoreOptionItemOrderItemCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteOptionItemOrderItemCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
