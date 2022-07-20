using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService service)
        {
            _eventService = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        /// <returns>Events.</returns>
        [HttpGet(Name = "GetEvents")]
        public async Task<ActionResult<IEnumerable<EventData>>> GetAll()
        {
            return (List<EventData>) await _eventService.ShowAllEvents();
        }

        /// <summary>
        /// Get event by Id.
        /// </summary>
        /// <param name="id">Id of event.</param>
        /// <returns>Event.</returns>
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

        /// <summary>
        /// Creates new event.
        /// </summary>
        /// <param name="eventData">Event.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates event.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <param name="eventData">Event.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete event.
        /// </summary>
        /// <param name="id">Event Id.</param>
        /// <returns></returns>
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