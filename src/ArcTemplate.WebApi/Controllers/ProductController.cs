using Microsoft.AspNetCore.Mvc;
using MediatR;
using ArcTemplate.Application.UseCases.GetProduct;
using System.Threading.Tasks;
using ArcTemplate.Application.UseCases.GetAllProducts;

namespace ArcTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var request = new GetProductRequest { Id = id };
            var response = await _mediator.Send(request);

            if (response == null)
            {
                _logger.LogWarning($"Product with id {id} not found.");
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var request = new GetAllProductsRequest();
            var response = await _mediator.Send(request);

            if (!response.Any())
            {
                _logger.LogWarning("No products found.");
                return NoContent();
            }

            return Ok(response);
        }
    }

}
