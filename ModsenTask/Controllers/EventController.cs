using Microsoft.AspNetCore.Mvc;
using ModsenTask.Services.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModsenTask.Controllers
{
    [ApiController]
    [Route("events")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService service)
        {
            _eventService = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet(Name = "GetEvents")]
        public async Task<ActionResult<IEnumerable<object>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<Object>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost(Name = "CreateEvent")]
        public async Task<IActionResult> Create(object even)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}", Name = "UpdateEvent")]
        public async Task<IActionResult> Update(int id, object even)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}