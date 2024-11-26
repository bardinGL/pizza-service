using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Commands.ProductCommand.HardDeleteProduct
{
    public class HardDeleteProductCommand : BaseCommand<Guid>, IRequest
    {
    }
}
