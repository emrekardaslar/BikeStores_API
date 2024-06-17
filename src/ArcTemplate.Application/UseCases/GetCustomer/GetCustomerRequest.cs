using MediatR;

namespace ArcTemplate.Application.UseCases.GetCustomer
{
    public class GetCustomerRequest : IRequest<GetCustomerResponse>
    {
        public int Id { get; set; }
    }
}
