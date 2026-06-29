using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Core.ApplicationService;
using static SampleApplication.Core.ApplicationService.PersonAppService;

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
        [HttpPut]
        public IActionResult AddPhoneNumberToPerson(AddNumberToPersonDto dto)
        {
            service.AddNumberToPerson(dto);
            return Ok();

        }
    }
}