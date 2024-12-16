using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs.Tables
{
    public class GetListTableIgnoreQueryFilterDto : PaginatedRequestDto
    {
        public bool IsDeleted { get; set; } = false;
        public int? TableNumber { get; set; }
        public int? Capacity { get; set; }
        public TableTypeEnum? Status { get; set; } = TableTypeEnum.Available;
        public Guid? ZoneId { get; set; }
    }
}
