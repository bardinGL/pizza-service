using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetFeedbackById
{
	public class GetFeedbackByIdQuery : IRequest<GetFeedbackByIdQueryResponse>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
