using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Features.Product.Commands.RemoveProduct
{
    public class RemoveProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}