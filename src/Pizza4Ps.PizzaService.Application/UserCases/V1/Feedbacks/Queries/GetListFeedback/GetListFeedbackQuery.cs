using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Feedbacks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Feedbacks.Queries.GetListFeedback
{
	public class GetListFeedbackQuery : IRequest<GetListFeedbackQueryResponse>
	{
		public GetListFeedbackDto GetListFeedbackDto { get; set; }
	}
}
