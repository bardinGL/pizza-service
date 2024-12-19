using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.StaffZones;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.CreateStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.DeleteStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.RestoreStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Commands.UpdateStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZone;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetListStaffZoneIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.StaffZones.Queries.GetStaffZoneById;

namespace Pizza4Ps.PizzaService.API.Controllers
{

    [Route("api/staff-zones")]
    [ApiController]
    public class StaffZonesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public StaffZonesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateStaffZoneDto request)
        {
            var result = await _sender.Send(new CreateStaffZoneCommand { CreateStaffZoneDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListStaffZoneIgnoreQueryFilterDto query)
        {
            var result = await _sender.Send(new GetListStaffZoneIgnoreQueryFilterQuery { GetListStaffZoneIgnoreQueryFilterDto = query });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListStaffZoneDto query)
        {
            var result = await _sender.Send(new GetListStaffZoneQuery { GetListStaffZoneDto = query });
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
            var result = await _sender.Send(new GetStaffZoneByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateStaffZoneDto request)
        {
            var result = await _sender.Send(new UpdateStaffZoneCommand { Id = id, UpdateStaffZoneDto = request });
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
            await _sender.Send(new RestoreStaffZoneCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteStaffZoneCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
