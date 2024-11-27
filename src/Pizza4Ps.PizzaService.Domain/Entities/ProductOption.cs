using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductOption : EntityAuditBase<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid OptionId { get; set; }
        public virtual Option Option { get; set; }
        public virtual Product Product { get; set; }
        private ProductOption() { }
        public ProductOption(Guid id, Guid optionId, Guid productid)
        {
            Id = id;
            OptionId = optionId;
            ProductId = productid;
        }
    }
}
