using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.CreateWorkingTime;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.DeleteWorkingTime;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.RestoreWorkingTime;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Commands.UpdateWorkingTime;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTime;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetListWorkingTimeIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetWorkingTimeById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/working-times")]
	[ApiController]
	public class WorkingTimesController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public WorkingTimesController(ISender sender, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateWorkingTimeDto request)
		{
			var result = await _sender.Send(new CreateWorkingTimeCommand { CreateWorkingTimeDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		[HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListWorkingTimeIgnoreQueryFilterDto query)
		{
			var result = await _sender.Send(new GetListWorkingTimeIgnoreQueryFilterQuery { GetListWorkingTimeIgnoreQueryFilterDto = query });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpGet()]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListWorkingTimeDto query)
		{
			var result = await _sender.Send(new GetListWorkingTimeQuery { GetListWorkingTimeDto = query });
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
			var result = await _sender.Send(new GetWorkingTimeByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateWorkingTimeDto request)
		{
			var result = await _sender.Send(new UpdateWorkingTimeCommand { Id = id, UpdateWorkingTimeDto = request });
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
			await _sender.Send(new RestoreWorkingTimeCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteWorkingTimeCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
