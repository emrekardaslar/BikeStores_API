using Microsoft.AspNetCore.Mvc;
using MediatR;
using BikeStores.Application.UseCases.GetProduct;
using BikeStores.Application.UseCases.GetAllProducts;

namespace BikeStores.API.Controllers
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
            var response = await _mediator.Send(new GetProductQuery { Id = id });

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
            var response = await _mediator.Send(new GetAllProductsQuery());

            if (!response.Any())
            {
                _logger.LogWarning("No products found.");
                return NoContent();
            }

            return Ok(response);
        }
    }

}
