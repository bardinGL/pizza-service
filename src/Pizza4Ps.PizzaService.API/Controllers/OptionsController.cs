using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Options;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.CreateOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.DeleteOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.RestoreOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Commands.UpdateOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetListOption;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetListOptionIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Option.Queries.GetOptionById;


namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public OptionsController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOptionDto request)
        {
            var result = await _sender.Send(new CreateOptionCommand { CreateOptionDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListOptionIgnoreQueryFilterDto query)
        {
            var result = await _sender.Send(new GetListOptionIgnoreQueryFilterQuery { GetListOptionIgnoreQueryFilterDto = query });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListOptionDto query)
        {
            var result = await _sender.Send(new GetListOptionQuery { GetListOptionDto = query });
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
            var result = await _sender.Send(new GetOptionByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateOptionDto request)
        {
            var result = await _sender.Send(new UpdateOptionCommand { Id = id, UpdateOptionDto = request });
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
            await _sender.Send(new RestoreOptionCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteOptionCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
