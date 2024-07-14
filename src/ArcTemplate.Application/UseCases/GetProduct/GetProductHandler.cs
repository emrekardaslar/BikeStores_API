using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ArcTemplate.Core.Interfaces;

namespace ArcTemplate.Application.UseCases.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<GetProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetProductById(request.Id);
            return Task.FromResult(new GetProductResponse { Id = product.Id, Name = product.Name, Price = product.Price, BrandId = product.BrandId });
        }
    }
}
