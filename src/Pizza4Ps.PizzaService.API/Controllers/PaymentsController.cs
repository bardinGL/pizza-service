using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Payments;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.CreatePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.DeletePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.RestorePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Commands.UpdatePayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPayment;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetListPaymentIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Payments.Queries.GetPaymentById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
	[Route("api/Payments")]
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

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] CreatePaymentDto request)
		{
			var result = await _sender.Send(new CreatePaymentCommand { CreatePaymentDto = request });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.CREATED_SUCCESS,
				StatusCode = StatusCodes.Status201Created
			});
		}

		[HttpGet("ignore-filter")]
		public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListPaymentIgnoreQueryFilterDto query)
		{
			var result = await _sender.Send(new GetListPaymentIgnoreQueryFilterQuery { GetListPaymentIgnoreQueryFilterDto = query });
			return Ok(new ApiResponse
			{
				Result = result,
				Message = Message.GET_SUCCESS,
				StatusCode = StatusCodes.Status200OK
			});
		}

		[HttpGet()]
		public async Task<IActionResult> GetListAsync([FromQuery] GetListPaymentDto query)
		{
			var result = await _sender.Send(new GetListPaymentQuery { GetListPaymentDto = query });
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
		public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePaymentDto request)
		{
			var result = await _sender.Send(new UpdatePaymentCommand { Id = id, UpdatePaymentDto = request });
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
