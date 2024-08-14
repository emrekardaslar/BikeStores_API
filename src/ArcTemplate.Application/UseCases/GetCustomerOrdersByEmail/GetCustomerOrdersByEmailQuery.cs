using MediatR;

namespace ArcTemplate.Application.UseCases.GetCustomerOrdersByEmail
{
    public class GetCustomerOrdersByEmailQuery: IRequest<List<GetCustomerOrdersByEmailResponse>>
    {
        public string Email { get; set; }
    }
}
