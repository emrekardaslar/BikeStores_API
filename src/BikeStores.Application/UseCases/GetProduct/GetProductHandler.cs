using MediatR;
using BikeStores.Core.Interfaces;
using AutoMapper;

namespace BikeStores.Application.UseCases.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetProductById(request.Id);

            // Use AutoMapper to map the domain entity to the response model
            var response = _mapper.Map<GetProductResponse>(product);

            return Task.FromResult(_mapper.Map<GetProductResponse>(product));
        }
    }
}
