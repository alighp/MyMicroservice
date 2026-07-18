using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Core.ApplicationService.Cusomers;
using SampleApplication.Core.ApplicationService.Customers;
using static SampleApplication.Core.ApplicationService.Customers.CustomerAppService;

namespace SampleApplication.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerAppService service;

        public CustomerController(CustomerAppService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult AddPerson(CreateCustomerDto dto)
        {
            service.AddPerson(dto);
            return Ok();
        }
        [HttpPut("change-first-name")]
        public IActionResult ChangeFirstName(string firstName, long personId)
        {
            service.ChangeFirstName(firstName,personId);
            return Ok();

        }
        [HttpPut("change-last-name")]
        public IActionResult LastFirstName(string lastName, long personId)
        {
            service.ChangeLastName(lastName, personId);
            return Ok();

        }
        [HttpPut("add-phone-number")]
        public IActionResult AddPhoneNumberToPerson(AddNumberToCustomerDto dto)
        {
            service.AddNumberToPerson(dto);
            return Ok();

        }
    }
}