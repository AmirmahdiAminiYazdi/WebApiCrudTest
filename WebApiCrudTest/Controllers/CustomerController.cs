using CleanArch.Application.Command;
using CleanArch.Application.Contract;
using CleanArch.Application.Query;
using CleanArch.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApiCrudTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMediator _mediator;
        public CustomerController(ICustomerService customerService, IMediator mediator)
        {
            _customerService = customerService;
            _mediator = mediator;
        }
        
        [HttpGet("AllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(result);
        }
        [HttpGet("Customer")]
        public async Task<IActionResult> GetCustomer([FromQuery][BindRequired] int customerId)
        {
            
                var result = await _mediator.Send(new GetCustomerByIdQuery() { CustomerId = customerId });
                return Ok(result);

        }
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] RegisterAccountDtos registerAccountDto)
        {
            var command = new CreateAccountCommand() { RegisterAccountDto = registerAccountDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("EditCustomer")]
        public async Task<IActionResult> EditCustomer([FromBody] EditCustometDtos editCustometDto)
        {
            var command = new EditAccountCommand() { EditCustometDto = editCustometDto };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer([Required][FromQuery] int CustomerId)
        {
            var command = new DeleteAccountCommand() { CustomerId = CustomerId };
            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}
