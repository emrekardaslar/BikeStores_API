using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArcTemplate.Application.UseCases.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<Brand>> { }

    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBrandRepository _BrandRepository;
        private readonly ILogger<GetAllBrandsHandler> _logger;

        public GetAllBrandsHandler(IBrandRepository BrandRepository, ILogger<GetAllBrandsHandler> logger)
        {
            _BrandRepository = BrandRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var Brands = _BrandRepository.GetAllBrands();

            if (Brands == null || !Brands.Any())
            {
                _logger.LogWarning("No Brands found.");
                return Enumerable.Empty<Brand>();
            }

            return Brands;
        }
    }
}
