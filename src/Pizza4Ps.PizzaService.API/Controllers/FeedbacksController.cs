using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.CreateFeedback;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.DeleteFeedback;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.RestoreFeedback;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Commands.UpdateFeedback;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedback;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetFeedbackById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedbackIgnoreQueryFilter;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedbacksController : ControllerBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ISender _sender;

		public FeedbacksController(IHttpContextAccessor httpContextAccessor, ISender sender)
		{
			_httpContextAccessor = httpContextAccessor;
			_sender = sender;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreateFeedbackDto request)
		{
			var result = await _sender.Send(new CreateFeedbackCommand { CreateFeedbackDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		[HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListFeedbackIgnoreQueryFilterDto query)
		{
			var result = await _sender.Send(new GetListFeedbackIgnoreQueryFilterQuery { GetListFeedbackIgnoreQueryFilterDto = query });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpGet()]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListFeedbackDto query)
		{
			var result = await _sender.Send(new GetListFeedbackQuery { GetListFeedbackDto = query });
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
			var result = await _sender.Send(new GetFeedbackByIdQuery { Id = id });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateFeedbackDto request)
		{
			var result = await _sender.Send(new UpdateFeedbackCommand { Id = id, UpdateFeedbackDto = request });
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
			await _sender.Send(new RestoreFeedbackCommand { Ids = ids });
			return Ok(new ApiResponse
			{
				Message = Message.RESTORE_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpDelete()]
		public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
		{
			await _sender.Send(new DeleteFeedbackCommand { Ids = ids, isHardDelete = isHardDeleted });
			return Ok(new ApiResponse
			{
				Message = Message.DELETED_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}
	}
}
