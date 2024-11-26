using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand
{
    public class BaseCommand<Key>
    {
        public Key Id { get; set; }
    }
}
