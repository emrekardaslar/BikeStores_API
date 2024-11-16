using MediatR;

namespace BikeStores.Application.UseCases.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerResponse>
    {
        public int Id { get; set; }
    }
}
