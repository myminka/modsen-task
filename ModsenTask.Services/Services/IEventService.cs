using ModsenTask.Services.EntityFrameworkCore.Events.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModsenTask.Services.Services
{
    /// <summary>
    /// Represent a managment service for employees.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Show a list of events.
        /// </summary>
        /// <returns>All events.</returns>
        Task<IList<EventData>> ShowAllEvents();

        /// <summary>
        /// Show an employee with specified identifier.
        /// </summary>
        /// <param name="eventId">Event identifier.</param>
        /// <returns>Event, if event exists, otherwise returns default value.</returns>
        Task<EventData> ShowEventById(int eventId);

        /// <summary>
        /// Creates a new event.
        /// </summary>
        /// <param name="eventData">An event to create.</param>
        /// <returns>An identifier of a created employee.</returns>
        Task<int> CreateEvent(EventData eventData);

        /// <summary>
        /// Destroy an existed event.
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>True if event was deleted successfully, otherwise false./</returns>
        Task<bool> DeleteEvent(int eventId);

        /// <summary>
        /// Updates a event.
        /// </summary>
        /// <param name="eventId">An event identifier.</param>
        /// <param name="eventData">True if employee is updated; otherwise false.</param>
        /// <returns>True if event was updated successfully, otherwise false.</returns>
        Task<bool> UpdateEvent(int eventId, EventData eventData);
    }
}