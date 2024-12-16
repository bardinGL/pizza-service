using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.TableBookings;
using Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.CreateTableBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.DeleteTableBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.RestoreTableBooking;
using Pizza4Ps.PizzaService.Application.UserCases.V1.TableBookings.Commands.UpdateTableBooking;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TableBookingsController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public TableBookingsController(IHttpContextAccessor httpContextAccessor, ISender sender)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateTableBookingDto request)
		{
			var result = await _sender.Send(new CreateTableBookingCommand { CreateTableBookingDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		//[HttpGet("ignore-filter")]
		//public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListTableBookingIgnoreQueryFilterDto query)
		//{
		//	var result = await _sender.Send(new GetListTableBookingIgnoreQueryFilterQuery { GetListTableBookingIgnoreQueryFilterDto = query });
		//	return Ok(new ApiResponse
		//	{
		//		Result = result,
		//		Message = Message.GET_SUCCESS,
		//		StatusCode = StatusCodes.Status200OK
		//	});
		//}

		//[HttpGet()]
		//public async Task<IActionResult> GetListAsync([FromQuery] GetListTableBookingDto query)
		//{
		//	var result = await _sender.Send(new GetListTableBookingQuery { GetListTableBookingDto = query });
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
		//	var result = await _sender.Send(new GetTableBookingByIdQuery { Id = id });
		//	return Ok(new ApiResponse
		//	{
		//		Result = result,
		//		Message = Message.GET_SUCCESS,
		//		StatusCode = StatusCodes.Status200OK
		//	});
		//}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateTableBookingDto request)
		{
			var result = await _sender.Send(new UpdateTableBookingCommand { Id = id, UpdateTableBookingDto = request });
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
			await _sender.Send(new RestoreTableBookingCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteTableBookingCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
