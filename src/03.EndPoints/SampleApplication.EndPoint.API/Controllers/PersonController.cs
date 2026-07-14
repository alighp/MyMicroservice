using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Core.ApplicationService.People;
using static SampleApplication.Core.ApplicationService.People.PersonAppService;

namespace SampleApplication.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonAppService service;

        public PersonController(PersonAppService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult AddPerson(CreatePersonDto dto)
        {
            service.AddPerson(dto);
            return Ok();
        }
        [HttpPut("/change-first-name")]
        public IActionResult ChangeFirstName(string firstName, long personId)
        {
            service.ChangeFirstName(firstName,personId);
            return Ok();

        }
        [HttpPut("/change-last-name")]
        public IActionResult LastFirstName(string lastName, long personId)
        {
            service.ChangeLastName(lastName, personId);
            return Ok();

        }
        [HttpPut("add-phone-number")]
        public IActionResult AddPhoneNumberToPerson(AddNumberToPersonDto dto)
        {
            service.AddNumberToPerson(dto);
            return Ok();

        }
    }
}