using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SerilogDemo.Exceptions;

namespace SerilogDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 1)
            {
                int a = 5;
                int c = a / 0;
            }
            else if (id == 2)
            {
                throw new NotFoundException("record does not found");
            }
            else
            {
                throw new BadRequestException("Bad request");
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            int a = 5;
            int c = a / 0;
            return Ok();

            //try
            //{
            //    int a = 5;
            //    int c = a / 0;
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return StatusCode(500);
            //}
        }

    }
}
