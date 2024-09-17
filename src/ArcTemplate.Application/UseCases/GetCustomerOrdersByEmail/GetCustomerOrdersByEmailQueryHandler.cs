using AutoMapper;
using ArcTemplate.Core.Interfaces;
using MediatR;


namespace ArcTemplate.Application.UseCases.GetCustomerOrdersByEmail
{
    public class GetCustomerOrdersByEmailQueryHandler : IRequestHandler<GetCustomerOrdersByEmailQuery, List<GetCustomerOrdersByEmailResponse>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerOrdersByEmailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCustomerOrdersByEmailResponse>> Handle(GetCustomerOrdersByEmailQuery request, CancellationToken cancellationToken)
        {
            var orders = await _customerRepository.GetCustomerOrdersByEmailAsync(request.Email);

            // Use AutoMapper to map the orders to GetCustomerOrdersByEmailResponse
            var response = _mapper.Map<List<GetCustomerOrdersByEmailResponse>>(orders);

            return response;
        }
    }
}
