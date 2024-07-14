using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ArcTemplate.Core.Interfaces;

namespace ArcTemplate.Application.UseCases.GetBrand
{
    public class GetBrandHandler : IRequestHandler<GetBrandQuery, GetBrandResponse>
    {
        private readonly IBrandRepository _BrandRepository;

        public GetBrandHandler(IBrandRepository BrandRepository)
        {
            _BrandRepository = BrandRepository;
        }

        public Task<GetBrandResponse> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var Brand = _BrandRepository.GetBrandById(request.Id);
            return Task.FromResult(new GetBrandResponse { Id = Brand.Id, Name = Brand.Name });
        }
    }
}
