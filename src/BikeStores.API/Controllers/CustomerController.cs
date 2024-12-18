using Microsoft.AspNetCore.Mvc;
using MediatR;
using BikeStores.Application.UseCases.GetCustomer;
using BikeStores.Application.UseCases.GetCustomerOrdersByEmail;

namespace BikeStores.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var response = await _mediator.Send(new GetCustomerQuery { Id = id });
            return Ok(response);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetCustomerOrdersByEmail(string email)
        {
            var query = new GetCustomerOrdersByEmailQuery { Email = email };
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}
