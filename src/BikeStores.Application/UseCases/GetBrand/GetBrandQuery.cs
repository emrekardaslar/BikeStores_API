using MediatR;

namespace BikeStores.Application.UseCases.GetBrand
{
    public class GetBrandQuery : IRequest<GetBrandResponse>
    {
        public int Id { get; set; }
    }
}
