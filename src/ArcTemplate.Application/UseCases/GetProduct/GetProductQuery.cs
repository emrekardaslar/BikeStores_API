using MediatR;

namespace ArcTemplate.Application.UseCases.GetProduct
{
    public class GetProductQuery : IRequest<GetProductResponse>
    {
        public int Id { get; set; }
    }
}
