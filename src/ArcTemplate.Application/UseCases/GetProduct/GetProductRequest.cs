using MediatR;

namespace ArcTemplate.Application.UseCases.GetProduct
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        public int Id { get; set; }
    }
}
