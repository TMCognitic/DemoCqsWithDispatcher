using DemoCqsWithDispatcher.Forms;
using DemoCqsWithDispatcher.Models.Commands;
using DemoCqsWithDispatcher.Models.Entities;
using DemoCqsWithDispatcher.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Tools.Cqs;

namespace DemoCqsWithDispatcher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ContactController> _logger;
        private readonly IDispatcher _dispatcher;

        public ContactController(ILogger<ContactController> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dispatcher.Dispatch(new GetAllContactQuery()).Value);
        }

        [HttpPost]
        public IActionResult Post(AddContactForm form)
        {
            _dispatcher.Dispatch(new AddContactCommand(form.Nom, form.Prenom));
            return NoContent();
        }
    }
}
