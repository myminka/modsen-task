using Microsoft.AspNetCore.Mvc;
using ModsenTask.Services.EntityFrameworkCore.Events.Entities;
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
        public async Task<ActionResult<IEnumerable<EventData>>> GetAll()
        {
            return (List<EventData>) await _eventService.ShowAllEvents();
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<EventData>> GetById(int id)
        {
            var eventData = await _eventService.ShowEventById(id);

            if (eventData is null)
            {
                return this.NotFound();
            }

            return eventData;
        }

        [HttpPost(Name = "CreateEvent")]
        public async Task<IActionResult> Create(EventData eventData)
        {
            if (eventData is null)
            {
                return this.BadRequest();
            }

            await _eventService.CreateEvent(eventData);
            return this.CreatedAtAction(nameof(Create), eventData);
        }

        [HttpPut("{id}", Name = "UpdateEvent")]
        public async Task<IActionResult> Update(int id, EventData eventData)
        {
            if (eventData is null)
            {
                return this.NotFound();
            }

            if (await _eventService.UpdateEvent(id, eventData))
            {
                return this.NoContent();
            }

            return this.NotFound();
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _eventService.DeleteEvent(id))
            {
                return this.NoContent();
            }

            return this.NotFound();
        }
    }
}