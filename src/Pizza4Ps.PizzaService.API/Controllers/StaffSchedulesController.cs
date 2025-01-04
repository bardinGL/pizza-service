using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.StaffSchedules;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.CreateStaffSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.DeleteStaffSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.RestoreStaffSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Commands.UpdateStaffSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffSchedule;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetListStaffScheduleIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffSchedules.Queries.GetStaffScheduleById;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/staff-schedules")]
    [ApiController]
    public class StaffSchedulesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public StaffSchedulesController(ISender sender, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStaffScheduleDto request)
        {
            var result = await _sender.Send(new CreateStaffScheduleCommand { CreateStaffScheduleDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListStaffScheduleIgnoreQueryFilterDto query)
        {
            var result = await _sender.Send(new GetListStaffScheduleIgnoreQueryFilterQuery { GetListStaffScheduleIgnoreQueryFilterDto = query });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListStaffScheduleDto query)
        {
            var result = await _sender.Send(new GetListStaffScheduleQuery { GetListStaffScheduleDto = query });
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
            var result = await _sender.Send(new GetStaffScheduleByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateStaffScheduleDto request)
        {
            var result = await _sender.Send(new UpdateStaffScheduleCommand { Id = id, UpdateStaffScheduleDto = request });
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
            await _sender.Send(new RestoreStaffScheduleCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteStaffScheduleCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
