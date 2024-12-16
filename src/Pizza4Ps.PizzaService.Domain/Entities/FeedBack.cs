using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Feedback : EntityAuditBase<Guid>
    {
        public int Rating { get; set; }
        public string Comments { get; set; }
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
        
        public Feedback()
        {
        }

        public Feedback(Guid id,int rating, string comments, Guid orderId)
        {
            Id = id;
            Rating = rating;
            Comments = comments;
            OrderId = orderId;
        }
    }
}
