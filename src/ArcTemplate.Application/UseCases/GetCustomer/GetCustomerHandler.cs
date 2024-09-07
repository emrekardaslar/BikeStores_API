using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ArcTemplate.Core.Interfaces;

namespace ArcTemplate.Application.UseCases.GetCustomer
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, GetCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerById(request.Id);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {request.Id} not found.");
            }

            return new GetCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };
        }
    }
}
