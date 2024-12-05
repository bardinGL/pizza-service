using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Customer : EntityAuditBase<Guid>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        private Customer()
        {
        }

        public Customer(string fullName, string phone)
        {
            FullName = fullName;
            Phone = phone;
        }
    }
}
