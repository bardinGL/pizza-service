﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTableIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.DeleteTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.RestoreTable;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public TablesController(IHttpContextAccessor httpContextAccessor, ISender sender)
        {
            _httpContextAccessor = httpContextAccessor;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTableDto request)
        {
            var result = await _sender.Send(new CreateTableCommand { CreateTableDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListTableIgnoreQueryFilterDto query)
        {
            var result = await _sender.Send(new GetListTableIgnoreQueryFilterQuery { GetListTableIgnoreQueryFilterDto = query });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListTableDto query)
        {
            var result = await _sender.Send(new GetListTableQuery { GetListTableDto = query });
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
            var result = await _sender.Send(new GetTableByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateTableDto request)
        {
            var result = await _sender.Send(new UpdateTableCommand { Id = id, UpdateTableDto = request });
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
            await _sender.Send(new RestoreTableCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteTableCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
