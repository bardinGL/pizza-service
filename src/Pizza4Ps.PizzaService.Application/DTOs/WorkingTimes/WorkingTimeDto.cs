namespace Pizza4Ps.PizzaService.Application.DTOs.WorkingTimes
{
	public class WorkingTimeDto
	{
		public Guid Id { get; set; }
		public int DayOfWeek { get; set; }
		public string ShiftCode { get; set; }
		public string Name { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }
	}
}
