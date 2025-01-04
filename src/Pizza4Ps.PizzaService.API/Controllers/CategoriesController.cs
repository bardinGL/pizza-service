using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.API.Constants;
using Pizza4Ps.PizzaService.API.Models;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetCategoryById;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Queries.GetListCategoryIgnoreQueryFilter;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.CreateCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.DeleteCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.RestoreCategory;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.UpdateCategory;

namespace Pizza4Ps.PizzaService.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISender _sender;

        public CategoriesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryDto request)
        {
            var result = await _sender.Send(new CreateCategoryCommand { CreateCategoryDto = request });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.CREATED_SUCCESS,
                StatusCode = StatusCodes.Status201Created
            });
        }

        [HttpGet("ignore-filter")]
        public async Task<IActionResult> GetListIgnoreQueryFilterAsync([FromQuery] GetListCategoryIgnoreQueryFilterDto query)
        {
            var result = await _sender.Send(new GetListCategoryIgnoreQueryFilterQuery { GetListCategoryIgnoreQueryFilterDto = query });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet()]
        public async Task<IActionResult> GetListAsync([FromQuery] GetListCategoryDto query)
        {
            var result = await _sender.Send(new GetListCategoryQuery { GetListCategoryDto = query });
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
            var result = await _sender.Send(new GetCategoryByIdQuery { Id = id });
            return Ok(new ApiResponse
            {
                Result = result,
                Message = Message.GET_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryDto request)
        {
            var result = await _sender.Send(new UpdateCategoryCommand { Id = id, UpdateCategoryDto = request });
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
            await _sender.Send(new RestoreCategoryCommand { Ids = ids });
            return Ok(new ApiResponse
            {
                Message = Message.RESTORE_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteManyAsync(List<Guid> ids, bool isHardDeleted = false)
        {
            await _sender.Send(new DeleteCategoryCommand { Ids = ids, isHardDelete = isHardDeleted });
            return Ok(new ApiResponse
            {
                Message = Message.DELETED_SUCCESS,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
