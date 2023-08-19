using CleanArch.Application.Contract;
using CleanArch.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCrudTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] RegisterAccountDto registerAccountDto)
        {
            var result = _customerService.Register(registerAccountDto);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult EditCustomer(EditCustometDto editCustometDto)
        {
            var result = _customerService.Edit(editCustometDto);
            return Ok(result);
        }
    }
}
