﻿using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Product : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public ProductTypeEnum.ProductType ProductType { get; set; }

        public virtual Category Category { get; set; }

        public Product()
        {
        }

        public Product(Guid id, string name, decimal price, string description, Guid categoryId, ProductTypeEnum.ProductType productType)
        {
            Id = Id;
            Name = SetName(name);
            Price = price;
            Description = description;
            CategoryId = categoryId;
            ProductType = productType;
        }

        public void UpdateProduct(string name, decimal price, string description, Guid categoryId, ProductTypeEnum.ProductType productType)
        {
            Name = SetName(name);
            Price = price;
            Description = description;
            CategoryId = categoryId;
            ProductType = productType;
        }
        private string SetName(string name)
        {
        //    if (Name == null) throw new ValidationException("Invalid name");
            return name;
        }
    }
}
