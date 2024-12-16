using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Order : EntityAuditBase<Guid>
	{
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string Status { get; set; }
		public Guid TableId { get; set; }

		public virtual Table Table { get; set; }

		private Order()
		{
		}

		public Order(Guid id, DateTimeOffset startTime, DateTimeOffset endTime, string status, Guid tableId)
		{
			Id = id;
			StartTime = startTime;
			EndTime = endTime;
			Status = status;
			TableId = tableId;
		}

		public void UpdateOrder(DateTimeOffset startTime, DateTimeOffset endTime, string status, Guid tableId)
		{
			StartTime = startTime;
			EndTime = endTime;
			Status = status;
			TableId = tableId;
		}
	}
}
