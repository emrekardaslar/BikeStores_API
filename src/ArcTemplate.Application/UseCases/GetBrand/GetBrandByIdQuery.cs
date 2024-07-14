using MediatR;

namespace ArcTemplate.Application.UseCases.GetBrand
{
    public class GetBrandByIdQuery : IRequest<GetBrandResponse>
    {
        public int Id { get; set; }
    }
}
