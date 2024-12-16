using System.Xml.Linq;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Customer : EntityAuditBase<Guid>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }

        private Customer()
        {
        }

        public Customer(Guid id,string fullName, string phone)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
        }

		public void UpdateCustomer(string fullName, string phone)
		{
			FullName = fullName;
			Phone = phone;
		}
	}
}
