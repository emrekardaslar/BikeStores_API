using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTemplate.Application.UseCases.GetCustomerOrdersByEmail
{
    public class GetCustomerOrdersByEmailQuery: IRequest<List<GetCustomerOrdersByEmailResponse>>
    {
        public string Email { get; set; }
    }
}
