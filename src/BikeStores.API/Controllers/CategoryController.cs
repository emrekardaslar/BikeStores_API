﻿using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using BikeStores.Application.UseCases.GetCategoryProducts;


namespace BikeStores.API.Controllers
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
            var response = await _mediator.Send(new GetCategoryProductsQuery { Name = name });

            if (response == null)
            {
                _logger.LogWarning($"Products for category with id {name} not found.");
                return NotFound();
            }

            return Ok(response);
        }
    }

}
