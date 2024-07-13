using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using ArcTemplate.Application.UseCases.GetCategoryProducts;


namespace ArcTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryProducts(string name)
        {
            var request = new GetCategoryProductsRequest { Name = name };
            var response = await _mediator.Send(request);

            if (response == null)
            {
                _logger.LogWarning($"Products for category with id {name} not found.");
                return NotFound();
            }

            return Ok(response);
        }
    }

}
