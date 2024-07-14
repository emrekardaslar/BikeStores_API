using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArcTemplate.Application.UseCases.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }

    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetAllProductsHandler> _logger;

        public GetAllProductsHandler(IProductRepository productRepository, ILogger<GetAllProductsHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _productRepository.GetAllProducts();

            if (products == null || !products.Any())
            {
                _logger.LogWarning("No products found.");
                return Enumerable.Empty<Product>();
            }

            return products;
        }
    }
}
