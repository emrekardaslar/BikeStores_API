using Microsoft.AspNetCore.Mvc;
using MediatR;
using ArcTemplate.Application.UseCases.GetAllBrands;
using ArcTemplate.Application.UseCases.GetBrand;

namespace ArcTemplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BrandController> _logger;

        public BrandController(IMediator mediator, ILogger<BrandController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var request = new GetBrandRequest { Id = id };
            var response = await _mediator.Send(request);

            if (response == null)
            {
                _logger.LogWarning($"Brand with id {id} not found.");
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var request = new GetAllBrandsRequest();
            var response = await _mediator.Send(request);

            if (!response.Any())
            {
                _logger.LogWarning("No brands found.");
                return NoContent();
            }

            return Ok(response);
        }
    }

}