using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ArcTemplate.Core.Interfaces;
using AutoMapper;

namespace ArcTemplate.Application.UseCases.GetBrand
{
    public class GetBrandHandler : IRequestHandler<GetBrandQuery, GetBrandResponse>
    {
        private readonly IBrandRepository _BrandRepository;
        private readonly IMapper _mapper;

        public GetBrandHandler(IBrandRepository BrandRepository, IMapper mapper)
        {
            _BrandRepository = BrandRepository;
            _mapper = mapper;
        }

        public Task<GetBrandResponse> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var Brand = _BrandRepository.GetBrandById(request.Id);
            var response = _mapper.Map<GetBrandResponse>(Brand);
            return Task.FromResult(response);
        }
    }
}
