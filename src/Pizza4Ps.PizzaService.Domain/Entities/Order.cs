using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
	public class Order : EntityAuditBase<Guid>
	{
		public DateTimeOffset StartTime { get; set; }
		public DateTimeOffset EndTime { get; set; }
		public string Status { get; set; }
		public Guid OrderInTableId { get; set; }

		public virtual OrderInTable OrderInTable { get; set; }

		private Order()
		{
		}

		public Order(Guid id,DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid orderInTableId)
		{
			Id = id;
			StartTime = startTime;
			EndTime = endTime;
			Status = status;
			OrderInTableId = orderInTableId;
		}

		public void UpdateOrder(DateTimeOffset startTime, DateTimeOffset endTime, string? status, Guid orderInTableId)
		{
			StartTime = startTime;
			EndTime = endTime;
			Status = status;
			OrderInTableId = orderInTableId;
		}
	}
}
