﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Queries.GetProduct
{
    public class GetProductQueryResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
