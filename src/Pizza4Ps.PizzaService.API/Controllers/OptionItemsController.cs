using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.OptionItems;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.CreateOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.DeleteOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.RestoreOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Commands.UpdateOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItem;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetListOptionItemIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.OptionItems.Queries.GetOptionItemById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/option-items")]
	[ApiController]
	public class OptionItemsController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public OptionItemsController(ISender sender, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateOptionItemDto request)
		{
			var result = await _sender.Send(new CreateOptionItemCommand { CreateOptionItemDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		[HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOptionItemIgnoreQueryFilterDto query)
		{
			var result = await _sender.Send(new GetListOptionItemIgnoreQueryFilterQuery { GetListOptionItemIgnoreQueryFilterDto = query });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpGet()]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListOptionItemDto query)
		{
			var result = await _sender.Send(new GetListOptionItemQuery { GetListOptionItemDto = query });
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
			var result = await _sender.Send(new GetOptionItemByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOptionItemDto request)
		{
			var result = await _sender.Send(new UpdateOptionItemCommand { Id = id, UpdateOptionItemDto = request });
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
			await _sender.Send(new RestoreOptionItemCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteOptionItemCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
