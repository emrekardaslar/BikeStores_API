using ArcTemplate.Core.Interfaces;
using MediatR;


namespace ArcTemplate.Application.UseCases.GetCustomerOrdersByEmail
{
    public class GetCustomerOrdersByEmailQueryHandler: IRequestHandler<GetCustomerOrdersByEmailQuery, List<GetCustomerOrdersByEmailResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerOrdersByEmailQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<GetCustomerOrdersByEmailResponse>> Handle(GetCustomerOrdersByEmailQuery request, CancellationToken cancellationToken)
        {
            var orders = await _customerRepository.GetCustomerOrdersByEmailAsync(request.Email);

            var response = orders.Select(o => new GetCustomerOrdersByEmailResponse
            {
                OrderId = o.OrderId,
                OrderStatus = o.OrderStatus,
                OrderDate = o.OrderDate,
                RequiredDate = o.RequiredDate,
                ShippedDate = o.ShippedDate,
                StoreName = o.StoreName,
                StaffFirstName = o.StaffFirstName,
                StaffLastName = o.StaffLastName,
                TotalOrderValue = o.TotalOrderValue
            }).ToList();

            return response;
        }
    }
}
