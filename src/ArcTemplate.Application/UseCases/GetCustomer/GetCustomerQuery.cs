using MediatR;

namespace ArcTemplate.Application.UseCases.GetCustomer
{
    public class GetCustomerQuery : IRequest<GetCustomerResponse>
    {
        public int Id { get; set; }
    }
}
