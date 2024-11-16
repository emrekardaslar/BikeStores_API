using MediatR;

namespace BikeStores.Application.UseCases.GetCustomerOrdersByEmail
{
    public class GetCustomerOrdersByEmailQuery: IRequest<List<GetCustomerOrdersByEmailResponse>>
    {
        public string Email { get; set; }
    }
}
