using MediatR;

namespace ArcTemplate.Application.UseCases.GetBrand
{
    public class GetBrandRequest : IRequest<GetBrandResponse>
    {
        public int Id { get; set; }
    }
}
